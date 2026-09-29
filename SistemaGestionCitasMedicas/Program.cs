using System;
using SistemaGestionCitasMedicas.Notificaciones;
using SistemaGestionCitasMedicas.Persistencia;
using SistemaGestionCitasMedicas.Servicios;

namespace SistemaGestionCitasMedicas
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("   SISTEMA DE GESTIÓN DE CITAS MÉDICAS   ");
            Console.WriteLine("=============================================\n");

            // Instanciar dependencias
            IRepositorioCitas repositorio = new RepositorioCitasMemoria();
            INotificador notificador = new NotificadorEmail();
            AgendadorCitasService servicio = new AgendadorCitasService(repositorio, notificador);

            try
            {
                // 1. Agendar cita exitosamente
                DateTime fecha1 = DateTime.Now.AddDays(2);
                Console.WriteLine("--> Agendando cita para el paciente PAC-01...");
                servicio.AgendarCita("PAC-01", "MED-01", fecha1, "paciente@correo.com");

                // 2. Intentar agendar cita duplicada (debe arrojar excepción)
                Console.WriteLine("\n--> Intentando agendar cita duplicada para el mismo médico...");
                servicio.AgendarCita("PAC-02", "MED-01", fecha1, "otro@correo.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR CONTROLADO]: {ex.Message}");
            }

            Console.WriteLine("\n=============================================");
            Console.WriteLine("Presiona cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
