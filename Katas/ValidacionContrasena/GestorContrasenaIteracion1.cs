namespace ValidacionContrasena
{

    public abstract class GestorContrasenaBase
    {
        public abstract int LimiteCaracteresContrasena { get; }
        public abstract bool EsValida();
    }

    public class GestorContrasenaIteracion1 : GestorContrasenaBase
    {
        private string Contrasena;

        public override int LimiteCaracteresContrasena => 9;

        public GestorContrasenaIteracion1(string contrasena)
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

        private bool LaContrasenaNoTieneNumeros()
        {
            return ValidarCon(caracter => char.IsNumber(caracter));
        }

        private bool LaContrasenaNoContieneMinusculas()
        {
            return ValidarCon(caracter => char.IsLower(caracter));
        }

        private bool LaContrasenaNoContieneMayusculas()
        {
            return ValidarCon(caracter => char.IsUpper(caracter));
        }

        private bool LaContrasenaNoCumpleConLosCaracteresMinimos()
        {
            return ValidarCon(caracter => caracter < LimiteCaracteresContrasena);
        }

        public bool ValidarCon(Func<char, bool> predicado)
        {
            return Contrasena.Any(predicado);
        }
    }
}
