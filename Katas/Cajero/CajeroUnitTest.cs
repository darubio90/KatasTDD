
using FluentAssertions;

namespace CajeroDinero
{
    public class CajeroUnitTest
    {
        [Fact]
        public void ElCajero_Debe_CrearseConDinero()
        {
            List<Dinero> dineroIngresado = new()
            {
                new(500,1,Tipo.Billete)
            };
            //arrange
            var cajero = new Cajero(dineroIngresado);

            //act
            bool tieneDinero = cajero.TieneDinero();
            //assert
            tieneDinero.Should().BeTrue();

        }

        [Fact]
        public void ElCajero_Debe_CrearseSinDinero()
        {
            List<Dinero> dineroIngresado = new()
            {
            };
            //arrange
            var cajero = new Cajero(dineroIngresado);

            //act
            bool tieneDinero = cajero.TieneDinero();
            //assert
            tieneDinero.Should().BeFalse();

        }
    }

    public record Dinero
    {
        public Dinero(int valor, int unidades, Tipo tipo)
        {
            Valor = valor;
            Unidades = unidades;
            Tipo = tipo;
        }

        public int Valor { get; set; }
        public int Unidades { get; set; }
        public Tipo Tipo { get; set; }
    }

    public enum Tipo
    {
        Billete,
        Moneda
    }

    public class Cajero
    {
        public List<Dinero> Saldo { get; set; }
        public Cajero(List<Dinero> saldo)
        {
            Saldo = saldo;

        }

        public bool TieneDinero()
        {
            return true;
        }
    }
}
