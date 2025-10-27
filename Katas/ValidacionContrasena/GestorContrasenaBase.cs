namespace ValidacionContrasena
{
    public abstract class GestorContrasenaBase
    {
        protected GestorContrasenaBase(string contrasena, int limiteCaracteresContrasena)
        {
            Contrasena = contrasena;
            LimiteCaracteresContrasena = limiteCaracteresContrasena;
        }

        protected string Contrasena { get; set; }
        protected int LimiteCaracteresContrasena { get; set; }
        public abstract bool EsValida();

        protected bool LaContrasenaNoContieneMayusculas()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsUpper(caracter));
        }



        protected bool LaContrasenaNoContieneMinusculas()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsLower(caracter));
        }

        protected bool LaContrasenaNoTieneNumeros()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsNumber(caracter));
        }

        protected bool LaContrasenaNoCumpleConLosCaracteresMinimos()
        {
            return Contrasena.Length < LimiteCaracteresContrasena;
        }

        private bool ValidarSiCumpleCondicion(Func<char, bool> condicion)
        {
            return Contrasena.Any(condicion);
        }
    }
}