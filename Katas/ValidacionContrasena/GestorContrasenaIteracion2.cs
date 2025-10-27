namespace ValidacionContrasena
{
    public class GestorContrasenaIteracion2 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion2(string contrasena) : base(contrasena, limiteCaracteresContrasena: 7)
        {
        }

        public override bool EsValida()
        {
            if (LaContrasenaNoCumpleConLosCaracteresMinimos() is false
                || LaContrasenaNoContieneMayusculas() is false
                || LaContrasenaNoContieneMinusculas() is false
                || LaContrasenaNoTieneNumeros() is false)
                return false;

            return true;
        }
    }
}
