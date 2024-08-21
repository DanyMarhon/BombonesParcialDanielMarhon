using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientesDirecciones : IRepositorioClientesDirecciones
    {
        public void Agregar(ClienteDireccion clienteDireccion, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
                INSERT INTO ClientesDirecciones (ClienteId, DireccionId, TipoDireccionId)
                VALUES (@ClienteId, @DireccionId, @TipoDireccionId);";
            conn.Execute(query, clienteDireccion, tran);
        }

        public void BorrarPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "DELETE FROM ClientesDirecciones WHERE ClienteId = @ClienteId";
            conn.Execute(query, new { ClienteId = clienteId }, tran);
        }

        public List<ClienteDireccion> GetDireccionesPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT cd.*, d.*, p.*, pe.*, ci.* " +
                "FROM ClientesDirecciones cd " +
                "LEFT JOIN Direcciones d ON cd.DireccionId = d.DireccionId " +
                "LEFT JOIN Paises p ON d.PaisId = p.PaisId " +
                "LEFT JOIN ProvinciasEstados pe ON d.ProvinciaEstadoId = pe.ProvinciaEstadoId " +
                "LEFT JOIN Ciudades ci ON d.CiudadId = ci.CiudadId " +
                "WHERE cd.ClienteId = @ClienteId";
            //return conn.Query<ClienteDireccion, Direccion>(query, new { ClienteId = clienteId }, tran).ToList();

            var result = conn.Query<ClienteDireccion, Pais, ProvinciaEstado,Ciudad, Direccion, ClienteDireccion>(
    query,
    (clienteDireccion, pais, provinciaEstado, ciudad, direccion) =>
    {
        direccion.Pais = pais;
        direccion.ProvinciaEstado = provinciaEstado;
        direccion.Ciudad = ciudad;
        clienteDireccion.Direccion = direccion; // Asumiendo que ClienteDireccion tiene una propiedad Direccion
        return clienteDireccion;
    },
    new { ClienteId = clienteId },
    tran,
    splitOn: "DireccionId, PaisId, ProvinciaEstadoId, CiudadId"
).ToList();
            return result;
        }
    }
}
