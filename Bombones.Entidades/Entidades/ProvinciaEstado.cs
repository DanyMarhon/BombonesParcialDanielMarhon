namespace Bombones.Entidades.Entidades
{
    public class ProvinciaEstado
    {
        public int ProvinciaEstadoId { get; set; }
        public string NombreProvinciaEstado { get; set; } = null!;
        public int PaisId { get; set; }
        public Pais? Pais { get; set; }
    }
}
