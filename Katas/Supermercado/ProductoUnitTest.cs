using FluentAssertions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
    }

    public class Producto
    {
        private string Nombre { get; }
        private decimal Precio { get; }


        public static Producto Crear(string nombre, decimal valor)
        {
            LanzarExcepcionSinValorEsNegativo(valor);
            LanzarExcepcionSiNombreEsNuloOVacio(nombre);
            return new Producto(nombre, valor);
        }

        private static void LanzarExcepcionSinValorEsNegativo(decimal valor)
        {
            if (valor < 0)
                throw new Exception("El producto no puede crearse con valor negativo");
        }

        private Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }

        private static void LanzarExcepcionSiNombreEsNuloOVacio(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El producto no puede crearse sin nombre");
        }
    }
}
