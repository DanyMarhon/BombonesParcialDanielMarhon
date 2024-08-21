namespace Bombones.Entidades.Dtos
{
    public class ClienteListDto
    {
        public int ClienteId { get; set; }
        public int Documento { get; set; }
        public string? NombreCompleto { get; set; }
        public string? DireccionPrincipal { get; set; }
        public string? TelefonoPrincipal { get; set; }
    }
}
