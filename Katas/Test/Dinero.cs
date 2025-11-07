namespace Test
{
    public record Dinero
    {
        public Dinero(int valor, int unidad, Tipo tipo)
        {
            Valor = valor;
            Unidad = unidad;
            Tipo = tipo;
        }

        public int Valor { get; }
        public int Unidad { get; }
        public Tipo Tipo { get; }
    }
}
