using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioClientesDirecciones
    {
        void Agregar(ClienteDireccion clienteDireccion, SqlConnection conn, SqlTransaction? tran = null);
        void BorrarPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null);
        List<ClienteDireccion> GetDireccionesPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
