
using FluentAssertions;

namespace CajeroDinero
{
    public class CajeroUnitTest
    {
        [Fact]
        public void SiElCajeroExiste_Debe_CrearseConDinero()
        {
            //arrange
            var cajero = new Cajero();

            //act
            bool tieneDinero = cajero.TieneDinero();
            //assert
            tieneDinero.Should().BeTrue();

        }
    }

    public class Cajero
    {
        public Cajero()
        {
        }

        public bool TieneDinero()
        {
            throw new NotImplementedException();
        }
    }
}
