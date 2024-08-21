namespace Bombones.Entidades.Entidades
{
    public class Direccion
    {
        public int DireccionId { get; set; }
        public string Calle { get; set; } = null!;
        public string Altura { get; set; } = null!;
        public string? Entre1 { get; set; }
        public string? Entre2 { get; set; }
        public int? Piso { get; set; }
        public string? Depto { get; set; }

        public int PaisId { get; set; }
        public int ProvinciaEstadoId { get; set; }
        public int CiudadId { get; set; }
        public string CodPostal { get; set; } = null!;
        public Pais? Pais { get; set; }
        public ProvinciaEstado? ProvinciaEstado { get; set; }
        public Ciudad? Ciudad { get; set; }

        public override string ToString()
        {
            return $"{Calle} {Altura} - {Ciudad.NombreCiudad} - {ProvinciaEstado.NombreProvinciaEstado} - {Pais.NombrePais}";
        }
    }
}
