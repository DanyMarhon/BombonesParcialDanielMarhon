using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosTiposDeRellenos
    {
        void Borrar(int tipoDeRellenoId);
        bool EstaRelacionado(int tipoDeRellenoId);
        bool Existe(TipoDeRelleno tipoDeRelleno);
        List<TipoDeRelleno> GetLista();
        void Guardar(TipoDeRelleno tipoDeRelleno);
    }
}