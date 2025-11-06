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
    }

    public class Cajero
    {

        private List<Dinero> Saldo { get; }
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
            int dineroQueFalta = dineroSolicitado;
            List<Dinero> dineroAEntregar = new List<Dinero>();
            while (dineroQueFalta != 0)
            {
                Dinero dineroEncontrado = Saldo.First(x => x.Valor <= dineroQueFalta);
                dineroAEntregar.Add(new Dinero(dineroEncontrado.Valor, 1, dineroEncontrado.Tipo));
                dineroQueFalta -= dineroEncontrado.Valor;
            }

            return dineroAEntregar
                .GroupBy(x => new { x.Valor, x.Tipo })
                .Select(x => new Dinero(x.Key.Valor, x.Count(), x.Key.Tipo))
                .ToList();
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
