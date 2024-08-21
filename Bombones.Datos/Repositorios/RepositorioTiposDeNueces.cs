using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTiposDeNueces : IRepositorioTiposDeNueces
    {
        public RepositorioTiposDeNueces()
        {
        }

        public void Agregar(TipoDeNuez tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO TiposDeNueces (Descripcion) 
                    VALUES(@Descripcion); SELECT CAST(SCOPE_IDENTITY() as int)";

            var primaryKey = conn.QuerySingle<int>(insertQuery, tipo, tran);
            if (primaryKey > 0)
            {

                tipo.TipoDeNuezId = primaryKey;
                return;
            }

            throw new Exception("No se pudo agregar el tipo de Nuez");
        }

        public void Borrar(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM TiposDeNueces 
                    WHERE TipoDeNuezId=@TipoId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { tipoId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el tipo de Nuez");
            }
        }

        public void Editar(TipoDeNuez tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE TiposDeNueces 
                    SET Descripcion=@Descripcion 
                    WHERE TipoDeNuezId=@TipoDeNuezId";

            int registrosAfectados = conn.Execute(updateQuery, tipo, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el tipo de Nuez");
            }
        }

        public bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) 
                            FROM Bombones 
                                WHERE TipoDeNuezId=@TipoId";
            return conn.
                QuerySingle<int>(selectQuery, new { tipoId }) > 0;
        }

        public bool Existe(TipoDeNuez tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM TiposDeNueces ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (tipo.TipoDeNuezId == 0)
                {
                    conditional = "WHERE Descripcion = @Descripcion";
                }
                else
                {
                    conditional = @"WHERE Descripcion = @Descripcion
                                AND TipoDeNuezId<>@TipoDeNuezId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, tipo) > 0;


            }
            catch (Exception)
            {

                throw new Exception("No se pudo comprobar si existe el tipo de Nuez");
            }
        }

        public List<TipoDeNuez> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT TipoDeNuezId, Descripcion FROM 
                        TiposDeNueces ORDER BY Descripcion";
            return conn.Query<TipoDeNuez>(selectQuery).ToList();
        }
    }
}
