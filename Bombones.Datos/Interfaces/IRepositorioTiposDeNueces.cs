using Bombones.Entidades.Entidades;
using System.Data.SqlClient;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioTiposDeNueces
    {
        void Agregar(TipoDeNuez tipodenuez, SqlConnection conn, SqlTransaction? tran = null);
        void Borrar(int tipodenuezId, SqlConnection conn, SqlTransaction? tran = null);
        void Editar(TipoDeNuez tipodenuez, SqlConnection conn, SqlTransaction? tran = null);
        bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null);
        bool Existe(TipoDeNuez tipodenuez, SqlConnection conn, SqlTransaction? tran = null);
        List<TipoDeNuez> GetLista(SqlConnection conn, SqlTransaction? tran = null);

    }
}
