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
    }

    public class Word
    {
        public static string Wrap(string palabra, int v)
        {
            throw new NotImplementedException();
        }
    }
}
