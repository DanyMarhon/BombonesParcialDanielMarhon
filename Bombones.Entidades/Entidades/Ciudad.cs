namespace Bombones.Entidades.Entidades
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; } = null!;
        public int PaisId { get; set; }
        public int ProvinciaEstadoId { get; set; }
        public Pais? Pais { get; set; }
        public ProvinciaEstado? ProvinciaEstado { get; set; }
    }
}
