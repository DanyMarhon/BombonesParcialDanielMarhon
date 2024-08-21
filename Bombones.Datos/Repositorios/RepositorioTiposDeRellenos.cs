using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTiposDeRellenos : IRepositorioTiposDeRellenos
    {
        public RepositorioTiposDeRellenos()
        {

        }
        public void Agregar(TipoDeRelleno tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO TiposDeRellenos (Descripcion) 
                    VALUES(@Descripcion); SELECT CAST(SCOPE_IDENTITY() as int)";

            var primaryKey = conn.QuerySingle<int>(insertQuery, tipo, tran);
            if (primaryKey > 0)
            {

                tipo.TipoDeRellenoId = primaryKey;
                return;
            }

            throw new Exception("No se pudo agregar el tipo de Relleno");
        }

        public void Borrar(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM TiposDeRellenos 
                    WHERE TipoDeRellenoId=@TipoId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { tipoId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el tipo de Relleno");
            }
        }

        public void Editar(TipoDeRelleno tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE TiposDeRellenos 
                    SET Descripcion=@Descripcion 
                    WHERE TipoDeRellenoId=@TipoDeRellenoId";

            int registrosAfectados = conn.Execute(updateQuery, tipo, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el tipo de Relleno");
            }
        }

        public bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) 
                            FROM Bombones 
                                WHERE TipoDeRellenoId=@TipoId";
            return conn.
                QuerySingle<int>(selectQuery, new { tipoId }) > 0;
        }

        public bool Existe(TipoDeRelleno tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM TiposDeRellenos ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (tipo.TipoDeRellenoId == 0)
                {
                    conditional = "WHERE Descripcion = @Descripcion";
                }
                else
                {
                    conditional = @"WHERE Descripcion = @Descripcion
                            AND TipoDeRellenoId<>@TipoDeRellenoId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, tipo) > 0;

            }
            catch (Exception)
            {

                throw new Exception("No se pudo comprobar si existe el tipo de Relleno");
            }
        }

        public List<TipoDeRelleno> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT TipoDeRellenoId, Descripcion FROM 
                    TiposDeRellenos ORDER BY Descripcion";
            return conn.Query<TipoDeRelleno>(selectQuery).ToList();
        }
    }
}
