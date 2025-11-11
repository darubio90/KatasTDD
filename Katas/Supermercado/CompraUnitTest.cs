using FluentAssertions;

namespace Supermercado
{
    public class CompraUnitTest
    {
        [Fact]
        public void Si_CreoCompraConCantidadEnNegativa_Debe_LanzarExcepcion()
        {
            var producto = Producto.Crear("Leche", 5000);
            var excepcion = () => Compra.Crear(producto, -5);

            excepcion.Should().Throw<Exception>().WithMessage("*La cantidad no puede ser negativa");
        }

        [Fact]
        public void Si_CreoCompraConCantidadEnCero_Debe_LanzarExcepcion()
        {
            var producto = Producto.Crear("Leche", 5000);
            var excepcion = () => Compra.Crear(producto, 0);

            excepcion.Should().Throw<Exception>().WithMessage("*La cantidad no puede ser cero");
        }


        [Fact]
        public void Si_CreoCompraConProductoNulo_Debe_Lanzar_Exxcepcion()
        {
            var excepcion = () => Compra.Crear(null, 0);

            excepcion.Should().Throw<Exception>().WithMessage("*El producto no puede ser nulo");
        }
    }
}
