namespace ValidacionContrasena
{

    public class GestorContrasenaIteracion1 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion1(string contrasena) : base(contrasena, limiteCaracteresContrasena: 8)
        {
        }

        public override bool EsValida()
        {
            return TieneLongitudValida && TieneMayusculas && TieneMinusculas && TieneNumeros && TieneGuionBajo;
        }
    }
}