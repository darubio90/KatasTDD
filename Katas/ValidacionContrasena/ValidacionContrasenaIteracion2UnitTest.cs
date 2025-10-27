using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacionContrasena
{
    public class ValidacionContrasenaIteracion2UnitTest
    {
        [Fact]
        public void Si_ContraseñaTieneMenosDeSeisCaracteres_Debe_Retonar_False()
        {
            //arrange
            GestorContrasenaBase gestorContrasena = new GestorContrasenaIteracion2("pass");

            //act
            bool esValida = gestorContrasena.EsValida();

            //assert

            esValida.Should().BeFalse();

        }

    }

    public class GestorContrasenaIteracion2 : GestorContrasenaBase
    {
        private string Contrasena;

        public GestorContrasenaIteracion2(string contrasena)
        {
            Contrasena = contrasena;
        }

        public override bool EsValida()
        {
            if (Contrasena.Length < 6)
                return false;
            return true;
        }
    }
}
