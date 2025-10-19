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

        private string QuitarEspaciosYSignoDePuntuacion(string cadena)
        {
            const string vacio = "";
            const string espacios = " ";

            string caracteresAReemplazar = @"[.,;:¿?¡!\s]";

            return Regex.Replace(cadena, caracteresAReemplazar, vacio)
                .Replace(espacios, vacio);
        }
    }
}