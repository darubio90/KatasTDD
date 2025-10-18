using FluentAssertions;

namespace LeapYear
{
    public class LeapYearUnitTest
    {
        [Fact]
        public void Si_Anio_4_Es_Divisible_Entre_4_Retornar_True()
        {
            bool esBisiesto = Anio.EsBisiesto(4);
            esBisiesto.Should().BeTrue();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Si_Anio_No_Es_Divisible_Entre_4_Retornar_False(int anio)
        {
            bool esBisiesto = Anio.EsBisiesto(anio);
            esBisiesto.Should().BeFalse();
        }


        [Theory]
        [InlineData(1900)]
        [InlineData(1700)]
        [InlineData(1500)]
        public void Si_Anio_Es_Divisible_Entre_100_Pero_No_Divisible_Por_400_Retornar_False(int anio)
        {
            bool esBisiesto = Anio.EsBisiesto(anio);
            esBisiesto.Should().BeFalse();
        }
    }

    public class Anio
    {
        public static bool EsBisiesto(int anio)
        {
            if (EsDivisiblePor(anio, 100) && EsDivisiblePor(anio, 400) is false)
                return false;
            return EsDivisiblePor(anio, 4);
        }

        private static bool EsDivisiblePor(int anio, int divisiblePor)
        {
            return anio % divisiblePor == 0;
        }
    }
}
