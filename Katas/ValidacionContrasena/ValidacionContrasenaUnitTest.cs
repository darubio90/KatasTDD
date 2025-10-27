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

        [Fact]
        public void Si_ContraseñaNoTieneMinusculas_Debe_Retonar_False()
        {
            //arrange
            var gestorContrasena = new GestorContrasena("PASS1234567");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

        [Fact]
        public void Si_ContraseñaNoTieneNumeros_Debe_Retonar_False()
        {
            //arrange
            var gestorContrasena = new GestorContrasena("Passwordddd");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

        [Fact]
        public void Si_ContraseñaNoTieneGuionBajo_Debe_Retonar_False()
        {
            //arrange
            var gestorContrasena = new GestorContrasena("Passwordddd1");

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

            if (LaContraseñaNoContieneMayusculas())
                return false;

            if (LaContraseñaNoContieneMinusculas())
                return false;

            if (LaContraseñaNoTieneNumeros())
                return false;

            return true;
        }

        private bool LaContraseñaNoTieneNumeros()
        {
            return !Contrasena.Any(char.IsNumber);
        }

        private bool LaContraseñaNoContieneMinusculas()
        {
            return !Contrasena.Any(char.IsLower);
        }

        private bool LaContraseñaNoContieneMayusculas()
        {
            return !Contrasena.Any(char.IsUpper);
        }

        private bool LaContrasenaNoCumpleConLosCaracteresMinimos()
        {
            return Contrasena.Length < LimiteCaracteresContrasena;
        }
    }
}
