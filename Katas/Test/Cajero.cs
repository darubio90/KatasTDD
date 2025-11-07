using FluentAssertions;

namespace Test
{
    public class Cajero
    {
        private List<Dinero> Saldo { get; }
        private List<Dinero> DineroAEntregar { get; set; }
        private Cajero(List<Dinero> dinero)
        {

            Saldo = dinero;
        }

        public static Cajero InicializarConDinero(List<Dinero> dineroInicial)
        {
            return new Cajero(dineroInicial);
        }

        public static Cajero InicializarConDineroPorDefecto()
        {
            var dinero = new List<Dinero>()
            {
                new (500,1,Tipo.Billete),
                new (200,1,Tipo.Billete),
                new (100,1,Tipo.Billete),
                new (50,1,Tipo.Billete),
                new (20,1,Tipo.Billete),
                new (10,1,Tipo.Billete),
                new (5,1,Tipo.Billete),
                new (2,1,Tipo.Moneda),
                new (1,1,Tipo.Moneda),
            };

            return new Cajero(dinero);
        }



        public List<Dinero> Retirar(int dineroSolicitado)
        {
            LanzarExcepcionSiElCajeroNoTieneSaldoParaElDineroSolicitado(dineroSolicitado);
            InicializarDineroAEntregar();

            int dineroQueFalta = dineroSolicitado;
            while (dineroQueFalta != 0)
            {
                Dinero dineroEncontrado = BuscarDineroDeIgualOMenorDenominacion(dineroQueFalta);
                AgregarDinero(dineroEncontrado);
                DescontarDinero(dineroEncontrado);
                dineroQueFalta -= dineroEncontrado.Valor;
            }

            return DineroAEntregar
                .GroupBy(dinero => new { dinero.Valor, dinero.Tipo })
                .Select(dinero => new Dinero(dinero.Key.Valor, dinero.Count(), dinero.Key.Tipo))
                .ToList();
        }

        private void InicializarDineroAEntregar()
        {
            DineroAEntregar = new();
        }

        private void DescontarDinero(Dinero dineroEncontrado)
        {
            RemoverDinero(dineroEncontrado);
            Saldo.Add(new(dineroEncontrado.Valor, dineroEncontrado.Unidad - 1, dineroEncontrado.Tipo));
        }

        private void RemoverDinero(Dinero dineroEncontrado)
        {
            Saldo.Remove(dineroEncontrado);
        }

        private void LanzarExcepcionSiElCajeroNoTieneSaldoParaElDineroSolicitado(int dineroSolicitado)
        {
            if (dineroSolicitado > SaldoCajero())
                throw new Exception("El cajero no tiene saldo suficiente para el dinero solicitado");
        }

        private int SaldoCajero()
        {
            return Saldo.Sum(dinero => dinero.Valor * dinero.Unidad);
        }

        private void AgregarDinero(Dinero dineroEncontrado)
        {
            DineroAEntregar.Add(new Dinero(dineroEncontrado.Valor, 1, dineroEncontrado.Tipo));
        }

        private Dinero BuscarDineroDeIgualOMenorDenominacion(int dineroQueFalta)
        {
            return Saldo
                .OrderByDescending(dinero => dinero.Valor)
                .Where(dinero => dinero.Unidad > 0)
                .First(dinero => dinero.Valor <= dineroQueFalta);
        }


    }
}
