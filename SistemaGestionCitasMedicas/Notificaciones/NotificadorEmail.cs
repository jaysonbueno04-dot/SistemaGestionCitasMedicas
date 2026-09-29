using System;

namespace SistemaGestionCitasMedicas.Notificaciones
{
    public class NotificadorEmail : INotificador
    {
        public void EnviarRecordatorio(string destino, string mensaje)
        {
            Console.WriteLine($"[EMAIL enviado a {destino}]: {mensaje}");
        }
    }
}