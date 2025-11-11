namespace Supermercado
{
    public class Compra
    {

        private Producto Producto { get; }
        public decimal Cantidad { get; }
        public decimal Total { get; private set; }

        public static Compra Crear(Producto producto, decimal cantidad)
        {
            LanzarExcepcionSiProductoEsNulo(producto);
            LanzarExcepcionSiCantidadNoEsValida(cantidad);
            return new Compra(producto, cantidad);
        }

        private static void LanzarExcepcionSiProductoEsNulo(Producto producto)
        {
            if (producto == null)
                throw new Exception("El producto no puede ser nulo");
        }

        private Compra(Producto producto, decimal cantidad)
        {
            Producto = producto;
            Cantidad = cantidad;
        }

        private static void LanzarExcepcionSiCantidadNoEsValida(decimal cantidad)
        {
            if (cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa");

            if (cantidad == 0)
                throw new Exception("La cantidad no puede ser cero");
        }

        public void CalcularTotal()
        {
            if (Producto.Nombre == "Cepillo")
                Calcular2X1();
            else
                Calcular20PorCientoDescuento();
        }

        private void Calcular20PorCientoDescuento()
        {
            const decimal porcentajeDescuento = 0.2m;
            decimal multiplicadorPorcentaje = 1 - porcentajeDescuento;
            Total = ((int)Cantidad * Producto.Precio * multiplicadorPorcentaje) + ((Cantidad - (int)Cantidad) * Producto.Precio);
        }

        private void Calcular2X1()
        {
            const int unidadQueCobraNormal = 1;

            Total = Cantidad % 2 == 0
                ? Cantidad / 2 * Producto.Precio
                : ((Cantidad - unidadQueCobraNormal) / 2 * Producto.Precio) + Producto.Precio;
        }
    }
}
