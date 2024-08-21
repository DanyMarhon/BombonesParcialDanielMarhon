namespace Bombones.Entidades.Entidades
{
    public class ClienteTelefono
    {
        public int ClienteId { get; set; }
        public int TelefonoId { get; set; }
        public int TipoTelefonoId { get; set; }

        // Relaciones
        public Cliente Cliente { get; set; } = null!;
        public Telefono Telefono { get; set; } = null!;
        public TipoTelefono TipoTelefono { get; set; } = null!;
    }
}
