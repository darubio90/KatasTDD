
namespace ValidacionContrasena
{
    public abstract class GestorContrasenaBase
    {
        protected GestorContrasenaBase(string contrasena, int limiteCaracteresContrasena)
        {
            Contrasena = contrasena;
            LimiteCaracteresContrasena = limiteCaracteresContrasena;
        }

        protected bool TieneLongitudValida => LaContrasenaContieneLosCaracteresMinimos();
        protected bool TieneMayusculas => LaContrasenaContieneMayusculas();
        protected bool TieneMinusculas => LaContrasenaContieneMinusculas();
        protected bool TieneNumeros => LaContrasenaContieneNumeros();
        protected bool TieneGuionBajo => LaContrasenaContieneGuionBajo();

        protected string Contrasena { get; set; }
        protected int LimiteCaracteresContrasena { get; set; }
        public abstract bool EsValida();

        private bool LaContrasenaContieneMayusculas()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsUpper(caracter));
        }


        private bool LaContrasenaContieneMinusculas()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsLower(caracter));
        }

        private bool LaContrasenaContieneNumeros()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsNumber(caracter));
        }

        private bool LaContrasenaContieneLosCaracteresMinimos()
        {
            return Contrasena.Length > LimiteCaracteresContrasena;
        }

        private bool ValidarSiCumpleCondicion(Func<char, bool> condicion)
        {
            return Contrasena.Any(condicion);
        }

        private bool LaContrasenaContieneGuionBajo()
        {
            return Contrasena.Contains("_");
        }

        internal List<string> ObtenerErrores()
        {
            throw new NotImplementedException();
        }
    }
}