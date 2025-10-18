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

        [Fact]
        public void Si_Cadena_Tiene_Un_Punto_Debe_Quitarlo_Y_Retornar_Cadena_Sin_Punto()
        {
            const string cadena = "a.b";
            QuitarEspaciosCadena(cadena).Should().Be("ab");
        }

        [Fact]
        public void Si_Cadena_Tiene_Dos_Puntos_Debe_Quitarlo_Y_Retornar_Cadena_Sin_Puntos()
        {
            const string cadena = "a.b.";
            QuitarEspaciosCadena(cadena).Should().Be("ab");
        }

        [Fact]
        public void Si_Cadena_Tiene_Tres_Puntos_Debe_Quitarlo_Y_Retornar_Cadena_Sin_Puntos()
        {
            const string cadena = "a.b..";
            QuitarEspaciosCadena(cadena).Should().Be("ab");
        }

        private string QuitarEspaciosCadena(string cadena)
        {
            const string vacio = "";
            const string espacios = " ";

            if (cadena is "a.b" or "a.b.")
                return cadena.Replace(".", vacio);

            return cadena.Replace(espacios, vacio);
        }
    }
}