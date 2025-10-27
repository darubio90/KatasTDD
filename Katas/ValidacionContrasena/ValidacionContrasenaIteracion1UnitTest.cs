using FluentAssertions;

namespace ValidacionContrasena
{
    public class ValidacionContrasenaIteracion1UnitTest
    {
        [Fact]
        public void Si_ContraseñaTieneMenosDeOchoCaracteres_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("pass123");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

        [Fact]
        public void Si_ContraseñaNoTieneMayusculas_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("pass1234567");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

        [Fact]
        public void Si_ContraseñaNoTieneMinusculas_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("PASS1234567");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

        [Fact]
        public void Si_ContraseñaNoTieneNumeros_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("Passwordddd");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

        [Fact]
        public void Si_ContraseñaNoTieneGuionBajo_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("Passwordddd1");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }

        [Fact]
        public void Si_ContraseñaEsValida_Debe_Retonar_True()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("Passwo_rdddd1");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeTrue();

        }
    }
}
