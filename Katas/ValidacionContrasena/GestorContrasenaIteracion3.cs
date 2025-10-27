namespace ValidacionContrasena
{
    public class GestorContrasenaIteracion3 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion3(string contrasena) : base(contrasena, limiteCaracteresContrasena: 16)
        {
        }

        public override bool EsValida()
        {
            if (LaContrasenaNoCumpleConLosCaracteresMinimos() is false
                || LaContrasenaNoContieneMayusculas() is false
                || LaContrasenaNoContieneMinusculas() is false
                || LaContrasenaNoTieneGuionBajo() is false)
                return false;
            return true;
        }
    }
}
