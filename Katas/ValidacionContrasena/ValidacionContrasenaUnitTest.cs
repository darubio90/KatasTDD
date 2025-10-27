using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace ValidacionContrasena
{
    public class ValidacionContrasenaUnitTest
    {
        [Fact]
        public void Si_ContraseñaTieneMenosDeOchoCaracteres_Debe_Retonar_False()
        {
            //arrange
            var gestorContrasena = new GestorContrasena("pass123");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

        [Fact]
        public void Si_ContraseñaNoTieneMayusculas_Debe_Retonar_False()
        {
            //arrange
            var gestorContrasena = new GestorContrasena("pass1234567");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }
    }

    public class GestorContrasena
    {
        private const int LimiteCaracteresContrasena = 9;
        private string Contrasena;

        public GestorContrasena(string contrasena)
        {
            Contrasena = contrasena;
        }

        public bool EsValida()
        {
            if (LaContrasenaNoCumpleConLosCaracteresMinimos())
                return false;
            return true;
        }

        private bool LaContrasenaNoCumpleConLosCaracteresMinimos()
        {
            return Contrasena.Length < LimiteCaracteresContrasena;
        }
    }
}
