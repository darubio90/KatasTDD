namespace ValidacionContrasena
{
    public class GestorContrasenaIteracion3 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion3(string contrasena) : base(contrasena, limiteCaracteresContrasena: 16)
        {
        }

        public override bool EsValida()
        {
            return TieneLongitudValida && TieneMayusculas && TieneMinusculas && TieneGuionBajo;
        }
    }
}
