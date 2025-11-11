namespace Supermercado
{
    public class Compra
    {

        private Producto Producto { get; }
        public decimal Cantidad { get; }
        public decimal Total { get; private set; }

        public static Compra Crear(Producto producto, int cantidad)
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

        private static void LanzarExcepcionSiCantidadNoEsValida(int cantidad)
        {
            if (cantidad < 0)
                throw new Exception("La cantidad no puede ser negativa");

            if (cantidad == 0)
                throw new Exception("La cantidad no puede ser cero");
        }

        public void CalcularTotal()
        {
            Calcular2X1();
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
