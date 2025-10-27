namespace ValidacionContrasena
{

    public class GestorContrasenaIteracion1 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion1(string contrasena) : base(contrasena, limiteCaracteresContrasena: 8)
        {
            Contrasena = contrasena;
        }

        public override bool EsValida()
        {
            if (LaContrasenaNoCumpleConLosCaracteresMinimos() is false
                || LaContrasenaNoContieneMayusculas() is false
                || LaContrasenaNoContieneMinusculas() is false
                || LaContrasenaNoTieneNumeros() is false
                || LaContrasenaNoTieneGuionBajo() is false)
                return false;

            return true;
        }
    }
}