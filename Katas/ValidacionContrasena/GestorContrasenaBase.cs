
namespace ValidacionContrasena
{
    public abstract class GestorContrasenaBase
    {
        protected GestorContrasenaBase(string contrasena, int limiteCaracteresContrasena)
        {
            Contrasena = contrasena;
            LimiteCaracteresContrasena = limiteCaracteresContrasena;
        }

        private const string LaContrasenaIngresadaNoTieneMinusculas = "La contraseña ingresada no es valida, debe agregarle minusculas.";
        private const string LaContraseñaIngresadaNoTieneNumeros = "La contraseña ingresada no es valida, debe agregarle un número.";
        private const string LaContraseñaIngresadaNoTieneGuionBajo = "La contraseña ingresada no es valida, debe agregarle un guión bajo.";
        private const string LaContraseñaIngresadaNoTieneMayusculas = "La contraseña ingresada no es valida, debe agregarle mayuscula.";
        private const string LaContraseñaIngresadaNoTieneLaLongitudMinima = "La contraseña ingresada no es valida, la longitud minima es de {0} y la ingresada es {1}.";

        protected bool TieneLongitudValida => LaContrasenaContieneLosCaracteresMinimos();
        protected bool TieneMayusculas => LaContrasenaContieneMayusculas();
        protected bool TieneMinusculas => LaContrasenaContieneMinusculas();
        protected bool TieneNumeros => LaContrasenaContieneNumeros();
        protected bool TieneGuionBajo => LaContrasenaContieneGuionBajo();

        protected string Contrasena { get; }
        protected int LimiteCaracteresContrasena { get; }
        public abstract bool EsValida();

        private bool LaContrasenaContieneMayusculas()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsUpper(caracter));
        }


        private bool LaContrasenaContieneMinusculas()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsLower(caracter));
        }

        private bool LaContrasenaContieneNumeros()
        {
            return ValidarSiCumpleCondicion(caracter => char.IsNumber(caracter));
        }

        private bool LaContrasenaContieneLosCaracteresMinimos()
        {
            return Contrasena.Length > LimiteCaracteresContrasena;
        }

        private bool ValidarSiCumpleCondicion(Func<char, bool> condicion)
        {
            return Contrasena.Any(condicion);
        }

        private bool LaContrasenaContieneGuionBajo()
        {
            return Contrasena.Contains("_");
        }

        public List<string> ObtenerErrores()
        {
            List<string> errrores = new();

            if (TieneLongitudValida is false)
                errrores.Add(string.Format(LaContraseñaIngresadaNoTieneLaLongitudMinima, LimiteCaracteresContrasena, Contrasena.Length));

            if (TieneMayusculas is false)
                errrores.Add(LaContraseñaIngresadaNoTieneMayusculas);

            if (TieneMinusculas is false)
                errrores.Add(LaContrasenaIngresadaNoTieneMinusculas);

            if (TieneNumeros is false)
                errrores.Add(LaContraseñaIngresadaNoTieneNumeros);


            if (TieneGuionBajo is false)
                errrores.Add(LaContraseñaIngresadaNoTieneGuionBajo);

            return errrores;
        }
    }
}