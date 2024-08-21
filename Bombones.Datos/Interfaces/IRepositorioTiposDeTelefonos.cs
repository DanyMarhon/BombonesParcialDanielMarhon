using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioTiposDeTelefonos
    {
        List<TipoTelefono> GetLista(SqlConnection conn, SqlTransaction? tran = null);
    }
}
