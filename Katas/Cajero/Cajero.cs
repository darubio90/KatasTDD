namespace CajeroDinero
{
    public class Cajero
    {
        private List<Dinero> Saldo { get; }

        public static Cajero Crear(List<Dinero> dineroIngresado)
        {
            LanzarExcepcionSiUnidadEsMenorOIgualACero(dineroIngresado);
            LanzarExcepcionSiValorEsMenorOIgualACero(dineroIngresado);

            return new Cajero(dineroIngresado);
        }

        public List<Dinero> SacarDinero(int dineroSolicitado)
        {
            LanzarExpcecionSiCajeroNoTieneElDineroSolicitado(dineroSolicitado);

            List<Dinero> dineroAEntregar = new();
            int dineroEntregado = 0;
            int dineroABuscar = dineroSolicitado; ;

            while (dineroEntregado < dineroSolicitado)
            {
                Dinero dineroEncontrado = BuscarDinero(dineroABuscar);
                dineroEntregado += dineroEncontrado.Valor;
                dineroABuscar -= dineroEncontrado.Valor;
                dineroAEntregar.Add(new(dineroEncontrado.Valor, 1, dineroEncontrado.Tipo));
                DescontarSaldoDeCajero(dineroEncontrado);
            }
            return EntregarDineroAgrupadoPorTipoYValor(dineroAEntregar);
        }

        private Cajero(List<Dinero> saldo)
        {
            Saldo = saldo;
        }

        private int SaldoCajero()
        {
            return Saldo.Sum(x => x.Valor * x.Unidades);
        }


        private static List<Dinero> EntregarDineroAgrupadoPorTipoYValor(List<Dinero> dineroAEntregar)
        {
            return dineroAEntregar
               .GroupBy(dinero => new { dinero.Tipo, dinero.Valor })
               .Select(dinero => new Dinero(dinero.Key.Valor, dinero.Count(), dinero.Key.Tipo))
               .ToList();
        }



        private void DescontarSaldoDeCajero(Dinero dineroEncontrado)
        {
            DescontarUnidadDinero(dineroEncontrado);
            RemoverDineroQueNoTieneUnidades();
        }

        private void DescontarUnidadDinero(Dinero dineroEncontrado)
        {
            Saldo.Remove(dineroEncontrado);
            Saldo.Add(new Dinero(dineroEncontrado.Valor, dineroEncontrado.Unidades - 1, dineroEncontrado.Tipo));
        }

        private void RemoverDineroQueNoTieneUnidades()
        {
            Saldo.RemoveAll(x => x.Unidades == 0);
        }

        private Dinero BuscarDinero(int dineroABuscar)
        {
            return Saldo
                .OrderByDescending(dinero => dinero.Valor)
                .First(dinero => dinero.Valor <= dineroABuscar && dinero.Unidades > 0);
        }

        private static void LanzarExcepcionSiUnidadEsMenorOIgualACero(List<Dinero> saldo)
        {
            if (saldo.Any(dinero => dinero.Unidades <= 0))
                throw new Exception("No se puede agregar dinero negativo con unidades negativas");
        }

        private static void LanzarExcepcionSiValorEsMenorOIgualACero(List<Dinero> saldo)
        {
            if (saldo.Any(dinero => dinero.Valor <= 0))
                throw new Exception("No agregar dinero negativo");
        }

        private void LanzarExpcecionSiCajeroNoTieneElDineroSolicitado(int dineroSolicitado)
        {
            if (dineroSolicitado > SaldoCajero())
                throw new Exception("El cajero automático no dispone de dinero suficiente, por favor acuda al cajero automático más cercano");
        }
    }
}