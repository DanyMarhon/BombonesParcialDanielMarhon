using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosFabricas
    {
        void Borrar(int fabricaId);
        bool EstaRelacionado(int fabricaId);

        void Guardar(Fabrica fabrica);
        bool Existe(Fabrica fabrica);
        List<FabricaListDto> GetLista(int? currentPage, int? pageSize);
        Fabrica? GetFabricaPorId(int fabricaId);
        int GetCantidad(Pais? paisSeleccionado = null, ProvinciaEstado? provSeleccionada = null, Ciudad? ciudadSeleccionada=null);
        int GetPaginaPorRegistro(string nombreFabrica, int pageSize);
    }
}
