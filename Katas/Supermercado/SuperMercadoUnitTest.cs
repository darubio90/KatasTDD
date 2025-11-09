using FluentAssertions;

namespace Supermercado
{
    public class SuperMercadoUnitTest
    {
        [Fact]
        public void Si_CreoProductoConNombreVacio_Debe_LanzarExpcecion()
        {
            var excepcion = () => new Producto("", 1000);

            excepcion.Should().Throw<Exception>().WithMessage("*El producto no puede crearse sin nombre");
        }
    }

    public class Producto
    {
        private string Nombre { get; }
        private decimal Precio { get; }
        public Producto(string nombre, decimal precio)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new Exception("El producto no puede crearse sin nombre");

            Nombre = nombre;
            Precio = precio;
        }
    }
}
