using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.ViewModels
{
    public class TelefonoConTipoVm
    {
        public Telefono Telefono { get; set; }
        public TipoTelefono? TipoTelefono { get; set; }

        public TelefonoConTipoVm(Telefono telefono, TipoTelefono? tipoTelefono)
        {
            Telefono = telefono;
            TipoTelefono = tipoTelefono;
        }

        public override string ToString()
        {
            return $"{Telefono.ToString()} - {TipoTelefono?.Descripcion}";
        }
    }
}
