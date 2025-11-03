
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
                new(200,2,Tipo.Billete),
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
            cajero.SacarDinero(1000);
            //act
            List<Dinero> dineroActual = cajero.DameElSaldo();

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(100,1,Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }

        [Fact]
        public void SiRetiro1000_Debe_RetonarExcepcionIndicandoQueNoHaySaldo()
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
            cajero.SacarDinero(1000);
            //act
            var excepcion = () => cajero.SacarDinero(1000);

            //assert

            excepcion.Should().Throw<Exception>().WithMessage("*El cajero automático no dispone de dinero suficiente, por favor acuda al cajero automático más cercano");
        }

        [Fact]
        public void SiRetiro200_Debe_DevolverConElDineroQueTengaUnidadesDisponibles()
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(200,0,Tipo.Billete),
                new(100,2,Tipo.Billete)
            };
            var cajero = new Cajero(dineroIngresado);
            //act
            List<Dinero> dineroActual = cajero.SacarDinero(200);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(100,2,Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }

        [Fact]
        public void SiRetiro1000_Debe_DevolverDiezBilletesDe100()
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(500,2,Tipo.Billete),
                new(100,10,Tipo.Billete)
            };
            var cajero = new Cajero(dineroIngresado);
            cajero.SacarDinero(1000);
            //act
            List<Dinero> dineroActual = cajero.SacarDinero(1000);

            //assert
            List<Dinero> dineroEsperado = new()
            {
                new(100,10,Tipo.Billete)
            };

            dineroActual.Should().Equal(dineroEsperado);
        }

        [Fact]
        public void SiIngresoDineroMenorACero_Debe_ReronarExcepcion()
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(-500,2,Tipo.Billete),
                new(100,10,Tipo.Billete)
            };
            //act
            var excepcion = () => new Cajero(dineroIngresado);

            //assert
            excepcion.Should().Throw<Exception>().WithMessage("*No agregar dinero negativo");
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
            LanzarExpcecionSiCajeroNoTieneElDineroSolicitado(dineroSolicitado);

            List<Dinero> dineroAEntregar = new();
            int dineroEntregado = 0;
            int dineroABuscar = dineroSolicitado; ;

            while (dineroEntregado < dineroSolicitado)
            {
                Dinero dineroEncontrado = BuscarDinero(dineroABuscar);
                dineroEntregado += dineroEncontrado.Valor;
                dineroABuscar -= dineroEncontrado.Valor;
                dineroAEntregar.Add(new(dineroEncontrado.Valor, 1, dineroEncontrado.Tipo));
                DescontarSaldoDeCajero(dineroEncontrado);
            }
            return EntregarDineroAgrupadoPorTipoYValor(dineroAEntregar);
        }

        private static List<Dinero> EntregarDineroAgrupadoPorTipoYValor(List<Dinero> dineroAEntregar)
        {
            return dineroAEntregar
               .GroupBy(dinero => new { dinero.Tipo, dinero.Valor })
               .Select(dinero => new Dinero(dinero.Key.Valor, dinero.Count(), dinero.Key.Tipo))
               .ToList();
        }

        private void LanzarExpcecionSiCajeroNoTieneElDineroSolicitado(int dineroSolicitado)
        {
            if (dineroSolicitado > SaldoCajero())
                throw new Exception("El cajero automático no dispone de dinero suficiente, por favor acuda al cajero automático más cercano");
        }

        private void DescontarSaldoDeCajero(Dinero dineroEncontrado)
        {
            DescontarUnidadDinero(dineroEncontrado);
            RemoverDineroQueNoTieneUnidades();
        }

        private void DescontarUnidadDinero(Dinero dineroEncontrado)
        {
            Saldo.Remove(dineroEncontrado);
            Saldo.Add(new Dinero(dineroEncontrado.Valor, dineroEncontrado.Unidades - 1, dineroEncontrado.Tipo));
        }

        private void RemoverDineroQueNoTieneUnidades()
        {
            Saldo.RemoveAll(x => x.Unidades == 0);
        }

        private Dinero BuscarDinero(int dineroABuscar)
        {
            return Saldo
                .OrderByDescending(dinero => dinero.Valor)
                .First(dinero => dinero.Valor <= dineroABuscar && dinero.Unidades > 0);
        }

        public List<Dinero> DameElSaldo()
        {
            return Saldo;
        }
    }
}