using FluentAssertions;
using System.Security.Cryptography.X509Certificates;

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
            QuitarEspaciosCadena(cadena).Should().Be(cadenaEsperada);
        }

        private string QuitarEspaciosCadena(string cadena)
        {
            const string vacio = "";
            const string espacios = " ";

            return cadena.Replace(espacios, vacio);
        }
    }
}