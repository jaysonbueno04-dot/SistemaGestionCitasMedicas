using System;

namespace SistemaGestionCitasMedicas.Notificaciones
{
    public class NotificadorSms : INotificador
    {
        public void EnviarRecordatorio(string destino, string mensaje)
        {
            Console.WriteLine($"[SMS enviado a {destino}]: {mensaje}");
        }
    }
}
