namespace CajeroDinero
{
    public record Dinero
    {
        public Dinero(int valor, int unidades, Tipo tipo)
        {
            Valor = valor;
            Unidades = unidades;
            Tipo = tipo;
        }

        public int Valor { get; set; }
        public int Unidades { get; set; }
        public Tipo Tipo { get; set; }
    }
}