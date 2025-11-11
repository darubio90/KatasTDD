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


        [Theory]
        [InlineData(1, 0.99)]
        [InlineData(2, 0.99)]
        [InlineData(3, 1.98)]
        [InlineData(4, 1.98)]
        [InlineData(5, 2.97)]
        [InlineData(6, 2.97)]
        public void Si_ComproCepillos_Debe_AplicarPromocion2X1(int cantidad, decimal valor)
        {
            var producto = Producto.Crear("Cepillo", 0.99m);
            var compra = Compra.Crear(producto, cantidad);
            compra.CalcularTotal();

            compra.Total.Should().Be(valor);
            compra.Cantidad.Should().Be(cantidad);
        }


        [Fact]
        public void Si_ComproMedioKiloDeManzana_Debe_CalcularValor()
        {
            var producto = Producto.Crear("Cepillo", 1.99m);
            var compra = Compra.Crear(producto, 0.5m);
            compra.CalcularTotal();

            compra.Total.Should().Be(0.995m);
            compra.Cantidad.Should().Be(0.5m);
        }

    }
}
