using FluentAssertions;

namespace Test
{
    public class CajeroUnitTest
    {
        [Fact]
        public void Si_Solicito500AlCajero_Debe_DevolverBilleteDe500()
        {

            //arrange
            var cajero = new Cajero();
            //act
            List<Dinero> dineroActual = cajero.Retirar(500);

            //assert
            List<Dinero> dineroEsperado = new() { new(500, 1, Tipo.Billete) };

            dineroActual.Should().Equal(dineroEsperado);
        }

        [Fact]
        public void Si_Solicito700AlCajero_Debe_DevolverBilleteDe500YOtroDe200()
        {

            //arrange
            var cajero = new Cajero();
            //act
            List<Dinero> dineroActual = cajero.Retirar(700);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(500, 1, Tipo.Billete),
                new(200, 1, Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }


        [Fact]
        public void Si_Solicito1725AlCajero_Debe_DevolverTresBilletesDe500UnoDe200UnoDe20UnoDe5()
        {

            //arrange
            List<Dinero> dineroInicial = new()
            {
                new(500, 3, Tipo.Billete),
                new(200, 1, Tipo.Billete),
                new(20, 1, Tipo.Billete),
                new(5, 1, Tipo.Billete)
            };
            var cajero = new Cajero(dineroInicial);
            //act
            List<Dinero> dineroActual = cajero.Retirar(1725);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(500, 3, Tipo.Billete),
                new(200, 1, Tipo.Billete),
                new(20, 1, Tipo.Billete),
                new(5, 1, Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }

        [Fact]
        public void Si_Solicito1000AlCajeroYNoLosTieneDisponibles_Debe_LanzaExcepcion()
        {
            //arrange
            List<Dinero> dineroInicial = new()
            {
                new(500, 1, Tipo.Billete),
            };
            var cajero = new Cajero(dineroInicial);
            //act
            var excepcion = () => cajero.Retirar(1000);

            //assert
            excepcion.Should().Throw<Exception>().WithMessage("*El cajero no tiene saldo suficiente para el dinero solicitado");
        }

        [Fact]
        public void Si_Solicito500AlCajero_Debe_DevolverLos500ConBilleteDeMayorDenominacion()
        {

            //arrange
            List<Dinero> dineroInicial = new()
            {
                new(100, 1, Tipo.Billete),
                new(500, 1, Tipo.Billete)
            };
            var cajero = new Cajero(dineroInicial);
            //act
            List<Dinero> dineroActual = cajero.Retirar(500);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(500, 1, Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }

        [Fact]
        public void Si_Solicito900AlCajero_Debe_DevolverUnBilleteDe500DosDe200()
        {

            //arrange
            List<Dinero> dineroInicial = new()
            {
                new(500, 3, Tipo.Billete),
                new(200, 2, Tipo.Billete),
                new(100, 1, Tipo.Billete),
                new(20, 1, Tipo.Billete),
                new(5, 1, Tipo.Billete)
            };
            var cajero = new Cajero(dineroInicial);
            cajero.Retirar(1000);
            //act
            List<Dinero> dineroActual = cajero.Retirar(900);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(500, 1, Tipo.Billete),
                new(200, 2, Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }
    }

    public class Cajero
    {

        private List<Dinero> Saldo { get; }
        private List<Dinero> DineroAEntregar { get; set; }
        public Cajero()
        {
            Saldo = new List<Dinero>()
            {
                new (500,1,Tipo.Billete),
                new (200,1,Tipo.Billete),
                new (100,1,Tipo.Billete),
                new (50,1,Tipo.Billete),
                new (20,1,Tipo.Billete),
                new (10,1,Tipo.Billete),
                new (5,1,Tipo.Billete),
                new (2,1,Tipo.Moneda),
                new (1,1,Tipo.Moneda),

            };
        }

        public Cajero(List<Dinero> saldo)
        {
            Saldo = saldo;
        }

        public List<Dinero> Retirar(int dineroSolicitado)
        {
            LanzarExcepcionSiElCajeroNoTieneSaldoParaElDineroSolicitado(dineroSolicitado);
            InicializarDineroAEntregar();

            int dineroQueFalta = dineroSolicitado;
            while (dineroQueFalta != 0)
            {
                Dinero dineroEncontrado = BuscarDineroDeIgualOMenorDenominacion(dineroQueFalta);
                AgregarDinero(dineroEncontrado);
                DescontarDinero(dineroEncontrado);
                dineroQueFalta -= dineroEncontrado.Valor;
            }

            return DineroAEntregar
                .GroupBy(dinero => new { dinero.Valor, dinero.Tipo })
                .Select(dinero => new Dinero(dinero.Key.Valor, dinero.Count(), dinero.Key.Tipo))
                .ToList();
        }

        private void InicializarDineroAEntregar()
        {
            DineroAEntregar = new();
        }

        private void DescontarDinero(Dinero dineroEncontrado)
        {
            Saldo.Remove(dineroEncontrado);
            Saldo.Add(new(dineroEncontrado.Valor, dineroEncontrado.Unidad - 1, dineroEncontrado.Tipo));
        }

        private void LanzarExcepcionSiElCajeroNoTieneSaldoParaElDineroSolicitado(int dineroSolicitado)
        {
            if (dineroSolicitado > SaldoCajero())
                throw new Exception("El cajero no tiene saldo suficiente para el dinero solicitado");
        }

        private int SaldoCajero()
        {
            return Saldo.Sum(dinero => dinero.Valor * dinero.Unidad);
        }

        private void AgregarDinero(Dinero dineroEncontrado)
        {
            DineroAEntregar.Add(new Dinero(dineroEncontrado.Valor, 1, dineroEncontrado.Tipo));
        }

        private Dinero BuscarDineroDeIgualOMenorDenominacion(int dineroQueFalta)
        {
            return Saldo
                .OrderByDescending(dinero => dinero.Valor)
                .Where(dinero => dinero.Unidad > 0)
                .First(dinero => dinero.Valor <= dineroQueFalta);
        }
    }

    public record Dinero
    {
        public Dinero(int valor, int unidad, Tipo tipo)
        {
            Valor = valor;
            Unidad = unidad;
            Tipo = tipo;
        }

        public int Valor { get; }
        public int Unidad { get; }
        public Tipo Tipo { get; }
    }

    public enum Tipo
    {
        Billete,
        Moneda
    }
}
