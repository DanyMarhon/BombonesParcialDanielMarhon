using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioTiposDeChocolates
    {
        void Agregar(TipoDeChocolate tipoDeChocolate, SqlConnection conn, SqlTransaction? tran = null);
        void Borrar(int tipoDeChocolateId, SqlConnection conn, SqlTransaction? tran = null);
        void Editar(TipoDeChocolate tipoDeChocolate, SqlConnection conn, SqlTransaction? tran = null);
        bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null);
        bool Existe(TipoDeChocolate tipoDeChocolate, SqlConnection conn, SqlTransaction? tran = null);
        List<TipoDeChocolate> GetLista(SqlConnection conn, SqlTransaction? tran = null);
    }
}