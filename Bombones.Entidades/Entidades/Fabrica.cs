namespace Bombones.Entidades.Entidades
{
    public class Fabrica
    {
        public int FabricaId { get; set; }
        public string NombreFabrica { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public int PaisId { get; set; }
        public int ProvinciaEstadoId { get; set; }
        public int CiudadId { get; set; }
        public Pais? Pais { get; set; }
        public ProvinciaEstado? ProvinciaEstado { get; set; }
        public Ciudad? Ciudad { get; set; }
    }
}
