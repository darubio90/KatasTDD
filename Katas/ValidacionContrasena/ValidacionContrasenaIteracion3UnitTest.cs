using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacionContrasena
{
    public class ValidacionContrasenaIteracion3UnitTest
    {
        [Fact]
        public void Si_ContraseñaTieneMenosDeDieciseisCaracteres_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion3("passwroddddrdfg");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();
        }
    }

    public class GestorContrasenaIteracion3 : GestorContrasenaBase
    {
        private string v;

        public GestorContrasenaIteracion3(string contrasena) : base(contrasena, limiteCaracteresContrasena: 16)
        {
        }

        public override bool EsValida()
        {
            throw new NotImplementedException();
        }
    }
}
