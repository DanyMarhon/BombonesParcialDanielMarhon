using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosTiposDeNueces
    {
        void Borrar(int tipoDeNuezId);
        bool EstaRelacionado(int tipoId);
        bool Existe(TipoDeNuez tipoDeNuez);
        List<TipoDeNuez> GetLista();
        void Guardar(TipoDeNuez tipoDeNuez);
    }
}