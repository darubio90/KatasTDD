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
            var cajero = new Cajero();
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

        public List<Dinero> Retirar(int dineroSolicitado)
        {
            int dineroQueFalta = dineroSolicitado;
            List<Dinero> dineroAEntregar = new List<Dinero>();
            while (dineroQueFalta != 0)
            {
                Dinero dineroEncontrado = Saldo.First(x => x.Valor <= dineroQueFalta);
                dineroAEntregar.Add(dineroEncontrado);
                dineroQueFalta -= dineroEncontrado.Valor;
            }

            return dineroAEntregar;
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
