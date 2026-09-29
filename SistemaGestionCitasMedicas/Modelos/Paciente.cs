using SistemaGestionCitasMedicas.Validaciones;

namespace SistemaGestionCitasMedicas.Modelos
{
    public class Paciente
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public Paciente(string id, string nombre, string telefono, string email)
        {
            ValidadorTexto.ValidarRequerido(id, nameof(id));
            ValidadorTexto.ValidarRequerido(nombre, nameof(nombre));

            Id = id;
            Nombre = nombre;
            Telefono = telefono;
            Email = email;
        }
    }
}