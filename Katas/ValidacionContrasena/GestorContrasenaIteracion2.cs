namespace ValidacionContrasena
{
    public class GestorContrasenaIteracion2 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion2(string contrasena) : base(contrasena, limiteCaracteresContrasena: 6)
        {
        }

        public override bool EsValida()
        {
            return TieneLongitudValida && TieneMayusculas && TieneMinusculas && TieneNumeros;
        }
    }
}
