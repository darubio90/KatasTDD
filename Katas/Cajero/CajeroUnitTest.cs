
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

        [Fact]
        public void SiRetiro200_Debe_DevolvermeUnBilleteDe200()
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(200,1,Tipo.Billete),
                new(100,1,Tipo.Billete),
                new(100,1,Tipo.Billete)
            };
            var cajero = new Cajero(dineroIngresado);
            //act
            List<Dinero> dineroActual = cajero.SacarDinero(200);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(200,1,Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }

        [Fact]
        public void SiRetiro1000_Debe_DevolvermeUnBilleteDe500DosDe200UnoDe100()
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(500,1,Tipo.Billete),
                new(200,1,Tipo.Billete),
                new(200,1,Tipo.Billete),
                new(100,1,Tipo.Billete)
            };
            var cajero = new Cajero(dineroIngresado);
            //act
            List<Dinero> dineroActual = cajero.SacarDinero(1000);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(500,1,Tipo.Billete),
                new(200,1,Tipo.Billete),
                new(200,1,Tipo.Billete),
                new(100,1,Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }


        [Fact]
        public void SiRetiro1000_Debe_DevolvermeSaldoDespuesDeRetiro()
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(500,1,Tipo.Billete),
                new(200,1,Tipo.Billete),
                new(200,1,Tipo.Billete),
                new(100,1,Tipo.Billete),
                new(100,1,Tipo.Billete)
            };
            var cajero = new Cajero(dineroIngresado);
            //act
            List<Dinero> dineroActual = cajero.DameElSaldo();

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(100,1,Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
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
            return SaldoCajero() > 0;
        }

        private int SaldoCajero()
        {
            return Saldo.Sum(x => x.Valor * x.Unidades);
        }

        public List<Dinero> SacarDinero(int dineroSolicitado)
        {
            List<Dinero> dineroAEntregar = new();
            int dineroEntregado = 0;
            int dineroABuscar = dineroSolicitado; ;

            while (dineroEntregado < dineroSolicitado)
            {
                Dinero dineroEncontrado = BuscarDinero(dineroABuscar);
                dineroEntregado += dineroEncontrado.Valor;
                dineroABuscar -= dineroEncontrado.Valor;
                dineroAEntregar.Add(dineroEncontrado);
                DescontarSaldoDeCajero(dineroEncontrado);
            }

            return dineroAEntregar;
        }

        private void DescontarSaldoDeCajero(Dinero dineroEncontrado)
        {
            Saldo.Remove(dineroEncontrado);
        }

        private Dinero BuscarDinero(int dineroABuscar)
        {
            return Saldo.OrderByDescending(x => x.Valor).First(dinero => dinero.Valor <= dineroABuscar);
        }

        internal List<Dinero> DameElSaldo()
        {
            throw new NotImplementedException();
        }
    }
}
