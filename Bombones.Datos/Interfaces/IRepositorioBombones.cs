using Bombones.Entidades.Dtos;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioBombones
    {
        List<BombonListDto> GetLista(SqlConnection conn, SqlTransaction? tran = null);

    }
}
