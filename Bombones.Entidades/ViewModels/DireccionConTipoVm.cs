using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.ViewModels
{
    public class DireccionConTipoVm
    {
        public Direccion Direccion { get; set; }
        public TipoDireccion? TipoDireccion { get; set; }

        public DireccionConTipoVm(Direccion direccion, TipoDireccion? tipoDireccion)
        {
            Direccion = direccion;
            TipoDireccion = tipoDireccion;
        }

        public override string ToString()
        {
            return $"{Direccion.Calle} {Direccion.Altura}, {Direccion.Ciudad?.NombreCiudad}, {TipoDireccion.Descripcion}";
        }
    }
}

