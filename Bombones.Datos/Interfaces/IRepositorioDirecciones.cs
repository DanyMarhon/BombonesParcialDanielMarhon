using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioDirecciones
    {
        int GetDireccionIdIfExists(Direccion direccion, SqlConnection conn,
            SqlTransaction? tran = null);

        void Agregar(Direccion direccion, SqlConnection conn,
            SqlTransaction? tran = null);
        Direccion? GetDireccionPorId(int direccionId, SqlConnection conn,
            SqlTransaction? tran = null);
        List<Direccion> GetDireccionesPorClienteId(int clienteId,
            SqlConnection conn, SqlTransaction? tran = null);
    }
}
