using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosPaises
    {
        void Borrar(int paisId);
        bool EstaRelacionado(int paisId);
        bool Existe(Pais pais);
        List<Pais>? GetLista(int? currentPage, int? pageSize);
        void Guardar(Pais pais);
        Pais? GetPaisPorId(int paisId);
        int GetCantidad();
        int GetPaginaPorRegistro(string nombrePais, int pageSize);
    }
}