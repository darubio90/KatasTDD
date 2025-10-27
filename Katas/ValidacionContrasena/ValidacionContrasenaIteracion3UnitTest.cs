using FluentAssertions;

namespace ValidacionContrasena
{
    public class ValidacionContrasenaIteracion3UnitTest
    {
        [Fact]
        public void Si_ContraseñaTieneMenosDeDieciseisCaracteres_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion3("passwroddddrdfg");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }

        [Fact]
        public void Si_ContraseñaNoTieneMayusculas_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion3("passwroddddrdfgssssssssssss");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }

        [Fact]
        public void Si_ContraseñaNoTieneMinusculas_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion3("PASSSSSSSWORDDDDDDDDDDDDDDDD");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }

        [Fact]
        public void Si_ContraseñaNoTieneGuionBajo_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion3("PassssssSWORDDDDDDDDDDDDDDDD");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }

        [Fact]
        public void Si_ContraseñaEsValida_Debe_Retonar_True()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion3("PassssssSWORDDD_DDDDDDDDDDDDD");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeTrue();
        }
    }

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
