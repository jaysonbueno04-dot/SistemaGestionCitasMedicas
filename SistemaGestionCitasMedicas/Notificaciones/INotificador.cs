namespace SistemaGestionCitasMedicas.Notificaciones
{
    public interface INotificador
    {
        void EnviarRecordatorio(string destino, string mensaje);
    }
}