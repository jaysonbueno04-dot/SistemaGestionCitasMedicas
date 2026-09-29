using SistemaGestionCitasMedicas.Validaciones;

namespace SistemaGestionCitasMedicas.Modelos
{
    public class Especialidad
    {
        public string Id { get; set; }
        public string Nombre { get; set; }

        public Especialidad(string id, string nombre)
        {
            ValidadorTexto.ValidarRequerido(id, nameof(id));
            ValidadorTexto.ValidarRequerido(nombre, nameof(nombre));

            Id = id;
            Nombre = nombre;
        }
    }
}