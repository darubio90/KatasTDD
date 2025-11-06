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
            return Saldo.Where(x => x.Valor == dineroSolicitado).ToList();
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

        public int Valor { get; set; }
        public int Unidad { get; set; }
        public Tipo Tipo { get; set; }
    }

    public enum Tipo
    {
        Billete,
        Moneda
    }
}
