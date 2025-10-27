namespace ValidacionContrasena
{

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