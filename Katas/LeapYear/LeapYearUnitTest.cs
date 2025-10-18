
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

        [Fact]
        public void Si_Anio_1_No_Es_Divisible_Entre_4_Retornar_False()
        {
            bool esBisiesto = Anio.EsBisiesto(1);
            esBisiesto.Should().BeFalse();

        }
    }

    public class Anio
    {
        public static bool EsBisiesto(int anio)
        {
            return true;
        }
    }
}
