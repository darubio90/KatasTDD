using FluentAssertions;

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

        [Fact]
        public void Si_ContraseñaEsValida_Debe_Retonar_True()
        {
            //arrange
            var gestorContrasena = new GestorContrasena("Passwo_rdddd1");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeTrue();

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
            if (LaContrasenaNoCumpleConLosCaracteresMinimos()
                || LaContrasenaNoContieneMayusculas() is false
                || LaContrasenaNoContieneMinusculas() is false
                || LaContrasenaNoTieneNumeros() is false
                || LaContrasenaNoTieneGuionBajo() is false
                )
                return false;

            return true;
        }

        private bool LaContrasenaNoTieneGuionBajo()
        {
            return Contrasena.Contains("_");
        }

        private bool LaContrasenaNoTieneNumeros()
        {
            return ValidarCon(caracter => char.IsNumber(caracter));
        }

        private bool LaContrasenaNoContieneMinusculas()
        {
            return ValidarCon(caracter => char.IsLower(caracter));
        }

        private bool LaContrasenaNoContieneMayusculas()
        {
            return ValidarCon(caracter => char.IsUpper(caracter));
        }

        private bool LaContrasenaNoCumpleConLosCaracteresMinimos()
        {
            return ValidarCon(caracter => caracter < LimiteCaracteresContrasena);
        }

        public bool ValidarCon(Func<char, bool> predicado)
        {
            return Contrasena.Any(predicado);
        }
    }
}
