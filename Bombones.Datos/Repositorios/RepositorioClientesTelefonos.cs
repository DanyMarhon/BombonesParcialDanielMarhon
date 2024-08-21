using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientesTelefonos : IRepositorioClientesTelefonos
    {
        public void Agregar(ClienteTelefono clienteTelefono, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            INSERT INTO ClientesTelefonos (ClienteId, TelefonoId, TipoTelefonoId)
            VALUES (@ClienteId, @TelefonoId, @TipoTelefonoId);
        ";
            conn.Execute(query, clienteTelefono, tran);
        }

        public void BorrarPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM ClientesTelefonos WHERE ClienteId = @ClienteId";
            conn.Execute(query, new { ClienteId = clienteId }, tran);
        }

        public List<ClienteTelefono> GetTelefonosPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM ClientesTelefonos ct " +
                "LEFT JOIN Telefonos t ON ct.TelefonoId = t.TelefonoId " +
                "WHERE ClienteId = @ClienteId";
            //return conn.Query<ClienteTelefono>(query, new { ClienteId = clienteId }, tran).ToList();
            var result = conn.Query<ClienteTelefono, Telefono, ClienteTelefono>(
    query,
    (clienteTelefono, telefono) =>
    {
        clienteTelefono.Telefono = telefono; // Asumiendo que ClienteDireccion tiene una propiedad Direccion
        return clienteTelefono;
    },
    new { ClienteId = clienteId },
    tran,
    splitOn: "TelefonoId"
).ToList();
            return result;
        }
    }
}
