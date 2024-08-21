using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioPaises
    {
        int GetCantidad(SqlConnection conn, SqlTransaction? tran = null);
        void Agregar(Pais pais, SqlConnection conn, SqlTransaction? tran = null);
        void Borrar(int paisId, SqlConnection conn, SqlTransaction? tran = null);
        void Editar(Pais pais, SqlConnection conn, SqlTransaction? tran = null);
        bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null);
        bool Existe(Pais pais, SqlConnection conn, SqlTransaction? tran = null);
        List<Pais>? GetLista(SqlConnection conn,int? currentPage, int? pageSize, SqlTransaction? tran = null);
        Pais? GetPaisPorId(int paisId, SqlConnection conn, SqlTransaction? tran = null);
        int GetPaginaPorRegistro(SqlConnection conn, string nombrePais, int totalPages);
    }
}
