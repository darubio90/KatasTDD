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

        [Fact]
        public void Si_LaPalabraTiene10CaracteresYElSaltoDeLineaEs3_Debe_HacerSaltoDeLinea()
        {
            // arrange
            string palabra = "abcdefghij";

            // act
            var resultado = Word.Wrap(palabra, 3);

            //assert

            resultado.Should().Be("abc\ndef\nghi\nj");

        }


    }

    public class Word
    {
        public static string Wrap(string palabra, int cantidadSaltosLinea)
        {
            List<string> palabras = PartirCadena(palabra, cantidadSaltosLinea);

            return AgregarSaltoDeLinea(palabras);
        }

        private static List<string> PartirCadena(string palabra, int cantidadSaltosLinea)
        {
            List<string> palabras = new();
            int inicio = 0;

            while (inicio < palabra.Length)
            {
                palabras.Add(ExtraerCadena(palabra, inicio, cantidadSaltosLinea));
                inicio += cantidadSaltosLinea;
            }

            return palabras;
        }

        private static string ExtraerCadena(string palabra, int inicio, int longitud)
        {
            return palabra.Substring(inicio, inicio + longitud > palabra.Length ? palabra.Length - inicio : longitud);
        }

        private static string AgregarSaltoDeLinea(List<string> palabras)
        {
            return string.Join("\n", palabras);
        }
    }
}
