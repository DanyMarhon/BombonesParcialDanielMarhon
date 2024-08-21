using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioCiudades
    {
        void Borrar(int ciudadId, SqlConnection conn, SqlTransaction tran);
        bool EstaRelacionado(int ciudadId, SqlConnection conn,
    SqlTransaction? tran = null);

        void Agregar(Ciudad ciudad, SqlConnection conn, SqlTransaction tran);
        void Editar(Ciudad ciudad, SqlConnection conn, SqlTransaction tran);
        bool Existe(Ciudad ciudad, SqlConnection conn,
            SqlTransaction? tran=null);
        List<CiudadListDto> GetLista(SqlConnection conn, int? currentPage,
            int? pageSize, SqlTransaction? tran = null);
        Ciudad? GetCiudadPorId(int ciudadId, SqlConnection conn);
        List<Ciudad> GetListaCombo(SqlConnection conn,Pais paisSeleccionado, ProvinciaEstado provinciaEstado);
        int GetCantidad(SqlConnection conn, Pais? paisSeleccionado,
            ProvinciaEstado? provSeleccionada,
            SqlTransaction? tran=null
            );
        int GetPaginaPorRegistro(SqlConnection conn, string nombreCiudad, int pageSize, SqlTransaction? tran=null);
    }
}
