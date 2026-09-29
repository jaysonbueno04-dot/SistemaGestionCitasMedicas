using System;

namespace SistemaGestionCitasMedicas.Validaciones
{
    public static class ValidadorTexto
    {
        public static void ValidarRequerido(string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException($"El campo '{nombreCampo}' es obligatorio.");
            }
        }
    }
}