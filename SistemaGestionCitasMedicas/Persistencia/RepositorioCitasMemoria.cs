using System;
using System.Collections.Generic;
using SistemaGestionCitasMedicas.Modelos;

namespace SistemaGestionCitasMedicas.Persistencia
{
    public class RepositorioCitasMemoria : IRepositorioCitas
    {
        private readonly List<Cita> _citas = new List<Cita>();

        public bool ExisteCitaEnHorario(string medicoId, DateTime fechaHora)
        {
            return _citas.Exists(c => c.MedicoId == medicoId &&
                                      c.FechaHora == fechaHora &&
                                      c.Estado != "CANCELADA");
        }

        public void Guardar(Cita cita)
        {
            var existente = _citas.Find(c => c.Id == cita.Id);
            if (existente == null)
            {
                _citas.Add(cita);
            }
        }

        public Cita ObtenerPorId(string citaId)
        {
            return _citas.Find(c => c.Id == citaId);
        }

        public List<Cita> ObtenerPorPaciente(string pacienteId)
        {
            return _citas.FindAll(c => c.PacienteId == pacienteId);
        }

        public List<Cita> ObtenerPorMedico(string medicoId)
        {
            return _citas.FindAll(c => c.MedicoId == medicoId);
        }
    }
}