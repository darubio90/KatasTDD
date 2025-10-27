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
            return ValidarCon(caracter => char.IsUpper(caracter));
        }

        private bool ValidarCon(Func<char, bool> predicado)
        {
            return Contrasena.Any(predicado);
        }

        protected bool LaContrasenaNoContieneMinusculas()
        {
            return ValidarCon(caracter => char.IsLower(caracter));
        }

        protected bool LaContrasenaNoTieneNumeros()
        {
            return ValidarCon(caracter => char.IsNumber(caracter));
        }

        protected bool LaContrasenaNoCumpleConLosCaracteresMinimos()
        {
            return ValidarCon(caracter => caracter < LimiteCaracteresContrasena);
        }
    }

    public class GestorContrasenaIteracion1 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion1(string contrasena) : base(contrasena, limiteCaracteresContrasena: 9)
        {
            Contrasena = contrasena;
        }

        public override bool EsValida()
        {
            if (LaContrasenaNoCumpleConLosCaracteresMinimos()
                || LaContrasenaNoContieneMayusculas() is false
                || LaContrasenaNoContieneMinusculas() is false
                || LaContrasenaNoTieneNumeros() is false
                || LaContrasenaNoTieneGuionBajo() is false)
                return false;

            return true;
        }

        private bool LaContrasenaNoTieneGuionBajo()
        {
            return Contrasena.Contains("_");
        }
    }
}