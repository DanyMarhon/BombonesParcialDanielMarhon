using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosProvinciasEstados
    {
        void Borrar(int provinciaEstadoId);
        bool EstaRelacionado(int provinciaEstadoId);
        bool Existe(ProvinciaEstado pe);
        int GetCantidad(Pais? pais=null);
        List<ProvinciaEstadoListDto> GetLista(int? currentPage, int? pageSize, Orden? orden = Orden.Ninguno,
            Pais ? paisSeleccionado=null);
        List<ProvinciaEstado> GetListaComboEstados(Pais pais);
        int GetPaginaPorRegistro(string nombreProvinciaEstado, int pageSize);
        ProvinciaEstado? GetProvinciaEstadoPorId(int provinciaEstadoId);
        void Guardar(ProvinciaEstado pe);
    }
}
