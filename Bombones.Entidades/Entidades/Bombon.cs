namespace Bombones.Entidades.Entidades
{
    public class Bombon
    {
        public int BombonId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public decimal PrecioCosto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int EnPedido { get; set; }
        public int NivelDeReposicion { get; set; }
        public bool Suspendido { get; set; }
        // Otros atributos específicos de Bombon
        public int TipoDeChocolateId { get; set; }
        public int TipoDeNuezId { get; set; }
        public int TipoDeRellenoId { get; set; }
        public int FabricaId { get; set; }
        // Propiedades de navegación
        public TipoDeChocolate? TipoDeChocolate { get; set; }
        public TipoDeNuez? TipoDeNuez { get; set; }
        public TipoDeRelleno? TipoDeRelleno { get; set; }
        public Fabrica? Fabrica { get; set; }

    }

}
