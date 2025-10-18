
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
    }

    public class Anio
    {
        public static bool EsBisiesto(int anio)
        {
            throw new NotImplementedException();
        }
    }
}
