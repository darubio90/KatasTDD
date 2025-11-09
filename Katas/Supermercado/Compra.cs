namespace Supermercado
{
    public class Compra
    {
        private Producto Producto { get; }
        private int Cantidad { get; }

        public static Compra Crear(Producto producto, int cantidad)
        {
            LanzarExcepcionSiCantidadNoEsValida(cantidad);
            return new Compra(producto, cantidad);
        }

        private Compra(Producto producto, int cantidad)
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
    }
}
