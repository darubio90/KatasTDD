using FluentAssertions;
using System.Text.RegularExpressions;

namespace RadarDePalindromos
{
    public class RadarDePalindromosUnitTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("MI")]
        [InlineData("MIL")]
        [InlineData("OSOO")]
        [InlineData("race car1")]
        [InlineData("axDbTbd6")]
        [InlineData("Hello, World!")]
        public void Si_La_Cadena_No_Se_Lee_Igual_De_Frente_Hacia_Atras_No_Es_Palindromo_Y_Retorna_False(string cadena)
        {
            bool esPalindromo = Palabra.EsPalindromo(cadena);
            esPalindromo.Should().BeFalse();
        }

        [Theory]
        [InlineData("M")]
        [InlineData("..M.¡M")]
        [InlineData("O.S.O   ")]
        [InlineData("Anita Lava lA .¡?!  ... tina!")]
        [InlineData("anna")]
        [InlineData("anna!")]
        [InlineData("race car")]
        [InlineData("Race car")]
        [InlineData("A man, a plan, a canal, Panama!")]

        public void Si_La_Cadena_Se_Lee_Igual_De_Frente_Hacia_Atras_Es_Palindromo_Y_RetornaTrue(string cadena)
        {
            bool esPalindromo = Palabra.EsPalindromo(cadena);
            esPalindromo.Should().BeTrue();
        }
    }

    public class Palabra
    {
        public static bool EsPalindromo(string cadena)
        {
            string cadenaAEvaluar = LimpiarCadena(cadena);

            if (cadenaAEvaluar.Length == 0)
                return false;

            return cadenaAEvaluar.SequenceEqual(cadenaAEvaluar.Reverse());
        }

        private static string LimpiarCadena(string cadena)
        {
            return Regex.Replace(cadena, @"[^\w]", string.Empty).ToLower();
        }
    }
}