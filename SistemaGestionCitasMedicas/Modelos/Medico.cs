using SistemaGestionCitasMedicas.Validaciones;

namespace SistemaGestionCitasMedicas.Modelos
{
    public class Medico
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string EspecialidadId { get; set; }

        public Medico(string id, string nombre, string especialidadId)
        {
            ValidadorTexto.ValidarRequerido(id, nameof(id));
            ValidadorTexto.ValidarRequerido(nombre, nameof(nombre));
            ValidadorTexto.ValidarRequerido(especialidadId, nameof(especialidadId));

            Id = id;
            Nombre = nombre;
            EspecialidadId = especialidadId;
        }
    }
}