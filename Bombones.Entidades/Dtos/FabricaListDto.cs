namespace Bombones.Entidades.Dtos
{
    public class FabricaListDto
    {
        public int FabricaId { get; set; }
        public string NombreFabrica { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? NombrePais { get; set; }
        public string? NombreProvinciaEstado { get; set; }
        public string? NombreCiudad { get; set; }
    }

}
