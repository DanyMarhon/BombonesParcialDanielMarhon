using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTiposDeChocolates : IRepositorioTiposDeChocolates
    {
        public RepositorioTiposDeChocolates()
        {

        }




        public void Agregar(TipoDeChocolate tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO TiposDeChocolates (Descripcion) 
                    VALUES(@Descripcion); SELECT CAST(SCOPE_IDENTITY() as int)";

            var primaryKey = conn.QuerySingle<int>(insertQuery, tipo, tran);
            if (primaryKey > 0)
            {

                tipo.TipoDeChocolateId = primaryKey;
                return;
            }

            throw new Exception("No se pudo agregar el Tipo de Chocolate");
        }

        public void Borrar(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM TiposDeChocolates 
                    WHERE TipoDeChocolateId=@TipoId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { tipoId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el tipo de Chocolate");
            }
        }

        public void Editar(TipoDeChocolate tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE TiposDeChocolates SET Descripcion=@Descripcion 
                    WHERE TipoDeChocolateId=@TipoDeChocolateId";

            int registrosAfectados = conn.Execute(updateQuery, tipo, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el Tipo de Chocolate");
            }
        }

        public bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) 
                            FROM Bombones 
                                WHERE TipoDeChocolateId=@TipoId";
            return conn.
                QuerySingle<int>(selectQuery, new { tipoId }) > 0;

        }

        public bool Existe(TipoDeChocolate tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM TiposDeChocolates ";
            string finalQuery = string.Empty;
            string conditional = string.Empty;
            if (tipo.TipoDeChocolateId == 0)
            {
                conditional = "WHERE Descripcion = @Descripcion";
            }
            else
            {
                conditional = @"WHERE Descripcion = @Descripcion
                                AND TipoDeChocolateId<>@TipoDeChocolateId";
            }
            finalQuery = string.Concat(selectQuery, conditional);
            return conn.QuerySingle<int>(finalQuery, tipo) > 0;
        }

        public List<TipoDeChocolate> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT TipoDeChocolateId, Descripcion FROM 
                    TiposDeChocolates ORDER BY Descripcion";
            return conn.Query<TipoDeChocolate>(selectQuery).ToList();
        }
    }
}
