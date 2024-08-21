using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioProvinciasEstados
    {
        int GetCantidad(SqlConnection conn, Pais? pais = null, SqlTransaction? tran = null);
        void Agregar(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran = null);
        void Borrar(int provinciaEstadoId, SqlConnection conn, SqlTransaction? tran = null);
        void Editar(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran = null);
        bool EstaRelacionado(int provinciaEstadoId, SqlConnection conn, SqlTransaction? tran = null);
        bool Existe(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran = null);


        List<ProvinciaEstadoListDto> GetLista(SqlConnection conn, int? currentPage, int? pageSize,  Orden ? orden=Orden.Ninguno,
            Pais? pais=null, SqlTransaction? tran = null);
        List<ProvinciaEstado> GetListaComboEstados(Pais pais, SqlConnection conn, SqlTransaction? tran = null);
        ProvinciaEstado? GetProvinciaEstadoPorId(int provinciaEstadoId, SqlConnection conn, SqlTransaction? tran = null);
        int GetPaginaPorRegistro(SqlConnection conn, string nombreProvinciaEstado,int pageSize, SqlTransaction? tran=null);
    }
}
