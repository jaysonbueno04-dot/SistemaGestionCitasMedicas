using System;
using System.Collections.Generic;
using SistemaGestionCitasMedicas.Modelos;

namespace SistemaGestionCitasMedicas.Persistencia
{
    public interface IRepositorioCitas
    {
        bool ExisteCitaEnHorario(string medicoId, DateTime fechaHora);
        void Guardar(Cita cita);
        Cita ObtenerPorId(string citaId);
        List<Cita> ObtenerPorPaciente(string pacienteId);
        List<Cita> ObtenerPorMedico(string medicoId);
    }
}