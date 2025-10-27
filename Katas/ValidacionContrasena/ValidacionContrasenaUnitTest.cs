using FluentAssertions;
using System.ComponentModel.DataAnnotations;

namespace ValidacionContrasena
{
    public class ValidacionContrasenaUnitTest
    {
        [Fact]
        public void Si_ContraseñaTieneMenosDeOchoCaracteres_Debe_Retonar_False()
        {
            //arrange
            var gestorContrasena = new GestorContrasena("pass123");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }
    }

    public class GestorContrasena
    {
        private string v;

        public GestorContrasena(string v)
        {
            this.v = v;
        }

        public bool EsValida()
        {
            throw new NotImplementedException();
        }
    }
}
