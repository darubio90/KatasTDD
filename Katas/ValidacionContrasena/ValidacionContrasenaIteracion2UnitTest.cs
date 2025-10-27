using FluentAssertions;

namespace ValidacionContrasena
{
    public class ValidacionContrasenaIteracion2UnitTest
    {
        [Fact]
        public void Si_ContraseñaTieneMenosDeSeisCaracteres_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion2("pass");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }

        [Fact]
        public void Si_ContraseñaNoTieneMayusculas_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion2("passwrod12345");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }

    }

    public class GestorContrasenaIteracion2 : GestorContrasenaBase
    {
        public GestorContrasenaIteracion2(string contrasena) : base(contrasena, limiteCaracteresContrasena: 6)
        {
        }

        public override bool EsValida()
        {
            if (Contrasena.Length < 6)
                return false;
            return true;
        }
    }
}
