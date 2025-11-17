using FluentAssertions;

namespace WordWrapTest
{
    public class WordWrapUnitTest
    {
        [Fact]
        public void Si_LaPalabraEsVacioYElSaltoDeLineaEs1_Debe_Mostrar_Vacio()
        {
            // arrange
            string palabra = "";

            // act
            var resultado = Word.Wrap(palabra, 1);

            //assert

            resultado.Should().Be("");

        }

        [Fact]
        public void Si_LaPalabraTiene4CaracteresYElSaltoDeLineaEs10_Debe_MostrarLaPalabraSinSaltoDeLinea()
        {
            // arrange
            string palabra = "this";

            // act
            var resultado = Word.Wrap(palabra, 10);

            //assert

            resultado.Should().Be("this");

        }

        [Fact]
        public void Si_LaPalabraTiene4CaracteresYElSaltoDeLineaEs2_Debe_HacerSaltoDeLinea()
        {
            // arrange
            string palabra = "word";

            // act
            var resultado = Word.Wrap(palabra, 2);

            //assert

            resultado.Should().Be("wo\nrd");

        }
    }

    public class Word
    {
        public static string Wrap(string palabra, int v)
        {
            return palabra;
        }
    }
}
