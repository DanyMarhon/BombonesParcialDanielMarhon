using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioTiposDeRellenos
    {
        void Agregar(TipoDeRelleno tipoDeRelleno, SqlConnection conn, SqlTransaction? tran = null);
        void Borrar(int tipoDeRellenoId, SqlConnection conn, SqlTransaction? tran = null);
        void Editar(TipoDeRelleno tipoDeRelleno, SqlConnection conn, SqlTransaction? tran = null);
        bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null);
        bool Existe(TipoDeRelleno tipoDeRelleno, SqlConnection conn, SqlTransaction? tran = null);
        List<TipoDeRelleno> GetLista(SqlConnection conn, SqlTransaction? tran = null);
    }
}