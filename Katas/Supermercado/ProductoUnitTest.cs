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
    }

    public class Producto
    {
        private string Nombre { get; }
        private decimal Precio { get; }


        public static Producto Crear(string nombre, decimal valor)
        {
            LanzarExcepcionSiNombreEsNuloOVacio(nombre);
            return new Producto(nombre, valor);
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
