using FluentAssertions;

namespace Test
{
    public class CajeroUnitTest
    {
        [Fact]
        public void Si_Solicito500AlCajero_Debe_DevolverBilleteDe500()
        {

            //arrange
            var cajero = Cajero.InicializarConDineroPorDefecto();
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
            var cajero = Cajero.InicializarConDineroPorDefecto();
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
            var cajero = Cajero.InicializarConDinero(dineroInicial);
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
            var cajero = Cajero.InicializarConDinero(dineroInicial);
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
            var cajero = Cajero.InicializarConDinero(dineroInicial);
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
            var cajero = Cajero.InicializarConDinero(dineroInicial);
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

        [Fact]
        public void Si_RealizoVariosRetirosElSaldoSeDebeIrRestandoCuandoNoTiene_Debe_LanzarExcepcion()
        {
            //arange
            List<Dinero> dineroInicial = new()
            {
                new(500, 2, Tipo.Billete),
                new(200, 3, Tipo.Billete),
                new(100, 5, Tipo.Billete),
                new(50, 12, Tipo.Billete),
                new(20, 20, Tipo.Billete),
                new(10, 50, Tipo.Billete),
                new(5, 100, Tipo.Billete),
                new(2, 250, Tipo.Billete),
                new(1, 500, Tipo.Billete)
            };
            var cajero = Cajero.InicializarConDinero(dineroInicial);
            cajero.Retirar(1725);
            cajero.Retirar(1825);
            //act
            var excepcion = () => cajero.Retirar(1600);

            //assert
            excepcion.Should().Throw<Exception>().WithMessage("*El cajero no tiene saldo suficiente para el dinero solicitado");
        }
    }
}
