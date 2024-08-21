using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioTiposDeDirecciones
    {
        List<TipoDireccion> GetLista(SqlConnection conn, SqlTransaction? tran = null);
    }
}
