using FluentAssertions;
using System.Security.Cryptography.X509Certificates;

namespace RadarDePalindromos
{
    public class RadarDePalindromosUnitTest
    {
        [Fact]
        public void Si_Cadena_Es_Vacio_Debe_Retornar_Vacio()
        {
            string cadena = QuitarEspacionCadena("");
            cadena.Should().Be(string.Empty);
        }

        private string QuitarEspacionCadena(string cadena)
        {
            return string.Empty;
        }
    }
}