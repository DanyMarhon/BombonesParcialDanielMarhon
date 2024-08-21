using Bombones.Entidades.Entidades;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosTiposDeChocolates
    {
        void Borrar(int tipoDeChocolateId);
        bool EstaRelacionado(int tipoDeChocolateId);
        bool Existe(TipoDeChocolate tipoDeChocolate);
        List<TipoDeChocolate> GetLista();
        void Guardar(TipoDeChocolate tipoDeChocolate);
    }
}