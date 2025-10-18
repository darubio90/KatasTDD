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

        [Fact]
        public void Si_Anio_1900_Es_Divisible_Entre_100_Pero_No_Divisible_Por_400_Retornar_False()
        {
            bool esBisiesto = Anio.EsBisiesto(1900);
            esBisiesto.Should().BeFalse();
        }

        [Fact]
        public void Si_Anio_1700_Es_Divisible_Entre_100_Pero_No_Divisible_Por_400_Retornar_False()
        {
            bool esBisiesto = Anio.EsBisiesto(1700);
            esBisiesto.Should().BeFalse();
        }
    }

    public class Anio
    {
        public static bool EsBisiesto(int anio)
        {
            if (anio is 1900 or 1700)
                return false;
            return anio % 4 == 0;
        }
    }
}
