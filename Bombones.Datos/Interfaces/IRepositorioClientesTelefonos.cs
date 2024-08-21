using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioClientesTelefonos
    {
        void Agregar(ClienteTelefono clienteTelefono, SqlConnection conn, SqlTransaction? tran = null);
        void BorrarPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null);
        List<ClienteTelefono> GetTelefonosPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
