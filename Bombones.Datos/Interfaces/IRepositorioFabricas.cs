using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioFabricas
    {
        void Borrar(int fabricaId, SqlConnection conn, SqlTransaction tran);
        bool EstaRelacionado(int fabricaId, SqlConnection conn,
                SqlTransaction? tran = null);

        void Agregar(Fabrica fabrica, SqlConnection conn, SqlTransaction tran);
        void Editar(Fabrica fabrica, SqlConnection conn, SqlTransaction tran);
        bool Existe(Fabrica fabrica, SqlConnection conn,
            SqlTransaction? tran=null);
        List<FabricaListDto> GetLista(SqlConnection conn, int? currentPage,
            int? pageSize, SqlTransaction? tran = null);
        Fabrica? GetFabricaPorId(int fabricaId, SqlConnection conn);
        int GetCantidad(SqlConnection conn, SqlTransaction? tran = null);
        int GetPaginaPorRegistro(SqlConnection conn, string nombreFabrica, int pageSize, SqlTransaction? tran = null);
    }
}
