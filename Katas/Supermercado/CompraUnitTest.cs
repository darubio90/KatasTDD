using FluentAssertions;

namespace Supermercado
{
    public class CompraUnitTest
    {
        [Fact]
        public void Si_CreoCompraConCantidadEnNegativa_Debe_LanzarExcepcion()
        {
            var producto = Producto.Crear("Leche", 5000);
            var excepcion = () => new Compra(producto, -5);

            excepcion.Should().Throw<Exception>().WithMessage("*La cantidad no puede ser negativa");
        }

    }

    public class Compra
    {
        private Producto Producto { get; }
        private int Cantidad { get; }

        public Compra(Producto producto, int cantidad)
        {
            LanzarExcepcionSiCantidadEsNegativa(cantidad);

            Producto = producto;
            Cantidad = cantidad;
        }

        private static void LanzarExcepcionSiCantidadEsNegativa(int cantidad)
        {
            if (cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa");
        }
    }
}
