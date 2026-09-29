using System;
using SistemaGestionCitasMedicas.Validaciones;

namespace SistemaGestionCitasMedicas.Modelos
{
    public class Cita
    {
        public string Id { get; private set; }
        public string PacienteId { get; private set; }
        public string MedicoId { get; private set; }
        public DateTime FechaHora { get; private set; }
        public string Estado { get; private set; } // "PROGRAMADA", "CANCELADA", "REPROGRAMADA"

        public Cita(string pacienteId, string medicoId, DateTime fechaHora)
        {
            ValidadorTexto.ValidarRequerido(pacienteId, nameof(pacienteId));
            ValidadorTexto.ValidarRequerido(medicoId, nameof(medicoId));

            if (fechaHora <= DateTime.Now)
            {
                throw new ArgumentException("La fecha de la cita debe ser en el futuro.");
            }

            Id = Guid.NewGuid().ToString();
            PacienteId = pacienteId;
            MedicoId = medicoId;
            FechaHora = fechaHora;
            Estado = "PROGRAMADA";
        }

        public void Cancelar()
        {
            Estado = "CANCELADA";
        }

        public void Reprogramar(DateTime nuevaFechaHora)
        {
            if (nuevaFechaHora <= DateTime.Now)
            {
                throw new ArgumentException("La nueva fecha debe ser en el futuro.");
            }

            FechaHora = nuevaFechaHora;
            Estado = "REPROGRAMADA";
        }
    }
}