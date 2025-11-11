namespace Supermercado
{
    public class Producto
    {
        public string Nombre { get; }
        public decimal Precio { get; }


        public static Producto Crear(string nombre, decimal valor)
        {
            LanzarExcepcionSinValorNoEsValido(valor);
            LanzarExcepcionSiNombreEsNuloOVacio(nombre);
            return new Producto(nombre, valor);
        }

        private static void LanzarExcepcionSinValorNoEsValido(decimal valor)
        {
            const int cero = 0;
            if (valor < cero)
                throw new Exception("El producto no puede crearse con valor negativo");

            if (valor == cero)
                throw new Exception("El producto no puede crearse con valor en cero");
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
