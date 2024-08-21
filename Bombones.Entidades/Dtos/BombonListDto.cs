namespace Bombones.Entidades.Dtos
{
    public class BombonListDto
    {
        public int BombonId { get; set; }
        public string NombreBombon { get; set; } = null!;
        public string? TipoDeChocolate { get; set; }
        public string? TipoDeNuez { get; set; }
        public string? TipoDeRelleno { get; set; }
        public string? Fabrica { get; set; }

        public decimal Precio { get; set; }
        public int Stock { get; set; }

    }
}
