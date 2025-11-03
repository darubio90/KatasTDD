using FluentAssertions;

namespace CajeroDinero
{
    public class CajeroUnitTest
    {

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
            var cajero = Cajero.Crear(dineroIngresado);
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
            var cajero = Cajero.Crear(dineroIngresado);
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
            var cajero = Cajero.Crear(dineroIngresado);
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
                new(100,2,Tipo.Billete)
            };
            var cajero = Cajero.Crear(dineroIngresado);
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
            var cajero = Cajero.Crear(dineroIngresado);
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

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SiIngresoDineroMenorACero_Debe_RetornarExcepcion(int valor)
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(valor,2,Tipo.Billete),
                new(valor,10,Tipo.Billete)
            };
            //act
            var excepcion = () => Cajero.Crear(dineroIngresado);

            //assert
            excepcion.Should().Throw<Exception>().WithMessage("*No agregar dinero negativo");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void SiIngresoDineroConUnidadesMenorIgualACero_Debe_RetornarExcepcion(int unidad)
        {
            //arrange
            List<Dinero> dineroIngresado = new()
            {
                new(500,unidad,Tipo.Billete),
                new(100,unidad,Tipo.Billete)
            };
            //act
            var excepcion = () => Cajero.Crear(dineroIngresado);

            //assert
            excepcion.Should().Throw<Exception>().WithMessage("*No se puede agregar dinero negativo con unidades negativas");
        }

    }
}