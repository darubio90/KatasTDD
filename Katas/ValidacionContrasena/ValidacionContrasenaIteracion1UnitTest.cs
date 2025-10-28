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

        [Fact]
        public void Si_ContraseñaFaltaGuionBajo_Debe_Retonar_ListaMensajesIndicandoQueFalta()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("Passwordddd1");

            //act
            List<string> errores = gestorContrasena.ObtenerErrores();

            //assert

            List<string> erroresEsperados = new()
            {
                "La contraseña ingresada no es valida, debe agregarle un guión bajo."
            };

            errores.Should().Equal(erroresEsperados);

        }

        [Fact]
        public void Si_ContraseñaFaltaGuionBajoYNumero_Debe_RetonarListaMensajeIndicandoQueFaltan()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("Passworddddsss");

            //act
            List<string> errores = gestorContrasena.ObtenerErrores();

            //assert

            List<string> erroresEsperados = new()
            {
                "La contraseña ingresada no es valida, debe agregarle un número.",
                "La contraseña ingresada no es valida, debe agregarle un guión bajo."
            };

            errores.Should().Equal(erroresEsperados);
        }

        [Fact]
        public void Si_ContraseñaFaltaGuionBajoNumeroYMinuscula_Debe_Retonar_MensajeIndicandoQueFaltan()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion1("PASSSSSSWORDDDDD");

            //act
            List<string> errores = gestorContrasena.ObtenerErrores();

            //assert

            List<string> erroresEsperados = new()
            {
                "La contraseña ingresada no es valida, debe agregarle minusculas.",
                "La contraseña ingresada no es valida, debe agregarle un número.",
                "La contraseña ingresada no es valida, debe agregarle un guión bajo."
            };

            errores.Should().Equal(erroresEsperados);
        }
    }
}
