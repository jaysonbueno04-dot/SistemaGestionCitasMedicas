using System;
using System.Collections.Generic;
using SistemaGestionCitasMedicas.Modelos;
using SistemaGestionCitasMedicas.Notificaciones;
using SistemaGestionCitasMedicas.Persistencia;

namespace SistemaGestionCitasMedicas.Servicios
{
    public class AgendadorCitasService
    {
        private readonly IRepositorioCitas _repositorio;
        private readonly INotificador _notificador;

        public AgendadorCitasService(IRepositorioCitas repositorio, INotificador notificador)
        {
            _repositorio = repositorio;
            _notificador = notificador;
        }

        public void AgendarCita(string pacienteId, string medicoId, DateTime fechaHora, string emailPaciente)
        {
            if (_repositorio.ExisteCitaEnHorario(medicoId, fechaHora))
            {
                throw new InvalidOperationException("El médico ya tiene una cita asignada en este horario.");
            }

            var cita = new Cita(pacienteId, medicoId, fechaHora);
            _repositorio.Guardar(cita);

            _notificador.EnviarRecordatorio(emailPaciente, $"Su cita fue agendada para el {fechaHora:dd/MM/yyyy HH:mm}.");
        }

        public void CancelarCita(string citaId)
        {
            var cita = _repositorio.ObtenerPorId(citaId);
            if (cita == null) throw new KeyNotFoundException("Cita no encontrada.");

            cita.Cancelar();
            _repositorio.Guardar(cita);
        }

        public void ReprogramarCita(string citaId, DateTime nuevaFechaHora)
        {
            var cita = _repositorio.ObtenerPorId(citaId);
            if (cita == null) throw new KeyNotFoundException("Cita no encontrada.");

            if (_repositorio.ExisteCitaEnHorario(cita.MedicoId, nuevaFechaHora))
            {
                throw new InvalidOperationException("El médico no tiene disponibilidad en el nuevo horario.");
            }

            cita.Reprogramar(nuevaFechaHora);
            _repositorio.Guardar(cita);
        }

        public List<Cita> ConsultarPorPaciente(string pacienteId) => _repositorio.ObtenerPorPaciente(pacienteId);
        public List<Cita> ConsultarPorMedico(string medicoId) => _repositorio.ObtenerPorMedico(medicoId);
    }
}