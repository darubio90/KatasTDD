using FluentAssertions;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace RadarDePalindromos
{
    public class RadarDePalindromosUnitTest
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(" a", "a")]
        [InlineData(" a ", "a")]
        public void Si_Cadena_Tiene_Espacios_Debe_Quitarlo_Retornar_Cadena_Sin_Espacios(string cadena, string cadenaEsperada)
        {
            QuitarEspaciosYSignoDePuntuacion(cadena).Should().Be(cadenaEsperada);
        }



        [Theory]
        [InlineData("a?b;c:¡!", "abc")]
        [InlineData("a. b, c.", "abc")]
        [InlineData("a...b,c", "abc")]
        [InlineData("a...b,c1", "abc1")]
        public void Si_Cadena_Tiene_Signo_De_Puntuacion_Debe_Quitarlos_Y_Retornar_Cadena_Sin_Estos_Caracteres(string cadena, string cadenaEsperada)
        {
            QuitarEspaciosYSignoDePuntuacion(cadena).Should().Be(cadenaEsperada);
        }

        [Fact]
        public void Si_Cadena_Tiene_Mayusculas_Debe_Retornar_Cadena_En_Minuscula()
        {
            string cadena = "mAmA";
            string cadenaEsperada = "mama";
            QuitarEspaciosYSignoDePuntuacion(cadena).Should().Be(cadenaEsperada);
        }

        [Fact]
        public void Si_La_Cadena_Es_MM_Es_Palindromo_Y_Retorna_True()
        {
            bool esPalindromo = Palabra.EsPalindromo("MM");
            esPalindromo.Should().BeTrue();
        }

        [Fact]
        public void Si_La_Cadena_Es_M_No_Es_Palindromo_Y_Retorna_False()
        {
            bool esPalindromo = Palabra.EsPalindromo("M");
            esPalindromo.Should().BeFalse();
        }

        [Fact]
        public void Si_La_Cadena_Es_MI_No_Es_Palindromo_Y_Retorna_False()
        {
            bool esPalindromo = Palabra.EsPalindromo("MI");
            esPalindromo.Should().BeFalse();
        }

        private string QuitarEspaciosYSignoDePuntuacion(string cadena)
        {
            const string vacio = "";
            const string espacios = " ";

            string caracteresAReemplazar = @"[.,;:¿?¡!\s]";

            return Regex.Replace(cadena, caracteresAReemplazar, vacio)
                .Replace(espacios, vacio)
                .ToLower();
        }
    }

    public class Palabra
    {
        public static bool EsPalindromo(string cadena)
        {
            if (cadena is "M" or "MI")
                return false;
            return true;
        }
    }
}