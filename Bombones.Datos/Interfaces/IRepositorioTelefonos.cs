using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioTelefonos
    {
        void Agregar(Telefono telefono, SqlConnection conn, SqlTransaction? tran = null);
        int GetTelefonoIdIfExist(Telefono telefono, SqlConnection conn, SqlTransaction tran);
        Telefono? GetTelefonoPorId(int telefonoId, SqlConnection conn, SqlTransaction? tran = null);
        List<Telefono> GetTelefonosPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null);
    }
}
