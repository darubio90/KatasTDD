using FluentAssertions;

namespace Supermercado
{
    public class ProductoUnitTest
    {

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void Si_CreoProductoConNombreNoValido_Debe_LanzarExpcecion(string nombre)
        {
            var excepcion = () => Producto.Crear(nombre, 1000);

            excepcion.Should().Throw<Exception>().WithMessage("*El producto no puede crearse sin nombre");
        }

        [Fact]
        public void Si_CreoProductorConValorNegativo_Debe_LanzarExcepcion()
        {
            var excepcion = () => Producto.Crear("Huevos", -1000);

            excepcion.Should().Throw<Exception>().WithMessage("*El producto no puede crearse con valor negativo");
        }

        [Fact]
        public void Si_CreoProductorConValorEnCero_Debe_LanzarExcepcion()
        {
            var excepcion = () => Producto.Crear("Huevos", 0);

            excepcion.Should().Throw<Exception>().WithMessage("*El producto no puede crearse con valor en cero");
        }
    }
}
