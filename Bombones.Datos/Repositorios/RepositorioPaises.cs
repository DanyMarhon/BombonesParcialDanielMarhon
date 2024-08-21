using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioPaises : IRepositorioPaises
    {
        public RepositorioPaises()
        {
        }
        public bool EstaRelacionado(int paisId, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) 
                        FROM ProvinciasEstados 
                            WHERE PaisId=@PaisId";
                return conn.
                    QuerySingle<int>(selectQuery, new { paisId }) > 0;

            }
            catch (Exception)
            {

                throw new Exception("No se pudo comprobar si existe el país");
            }

        }
        public bool Existe(Pais pais, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Paises ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (pais.PaisId == 0)
                {
                    conditional = "WHERE NombrePais = @NombrePais";
                }
                else
                {
                    conditional = @"WHERE NombrePais = @NombrePais
                            AND PaisId<>@PaisId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, pais) > 0;

            }
            catch (Exception)
            {

                throw new Exception("No se pudo comprobar si existe el país");
            }
        }
        public void Agregar(Pais pais, SqlConnection conn, SqlTransaction? tran)
        {
            int primaryKey = -1;
            string insertQuery = @"INSERT INTO Paises (NombrePais) 
                VALUES(@NombrePais); SELECT CAST(SCOPE_IDENTITY() as int)";

            primaryKey = conn.QuerySingle<int>(insertQuery, pais, tran);
            if (primaryKey > 0)
            {
                pais.PaisId = primaryKey;
                return;
            }

            throw new Exception("No se pudo agregar el país");
        }

        public void Borrar(int paisId, SqlConnection conn, SqlTransaction? tran)
        {
            string deleteQuery = @"DELETE FROM Paises 
                WHERE PaisId=@PaisId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { paisId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el país");
            }

        }
        public List<Pais>? GetLista(SqlConnection conn, int? currentPage, int? pageSize,  SqlTransaction? tran)
        {
            var selectQuery = @"SELECT PaisId, NombrePais FROM 
                Paises ORDER BY NombrePais";
            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet=(currentPage.Value-1)*pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }
            return conn.Query<Pais>(selectQuery).ToList();

        }

        public void Editar(Pais pais, SqlConnection conn, SqlTransaction? tran)
        {
            string updateQuery = @"UPDATE Paises SET NombrePais=@NombrePais 
                WHERE PaisId=@PaisId";

            int registrosAfectados = conn.Execute(updateQuery, pais, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el país");
            }
        }

        public Pais? GetPaisPorId(int paisId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT PaisId, NombrePais, 
                 FROM Paises 
                WHERE PaisId=@PaisId";
            return conn.QuerySingleOrDefault<Pais>(
                selectQuery, new { PaisId = paisId });
        }

        public int GetCantidad(SqlConnection conn, SqlTransaction? tran)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Paises";
            return conn.ExecuteScalar<int>(selectQuery);
        }

        public int GetPaginaPorRegistro(SqlConnection conn, string nombrePais, int pageSize)
        {
            var positionQuery = @"
                    WITH PaisOrdenado AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY NombrePais) AS RowNum,
                        NombrePais
                    FROM 
                        Paises
                )
                SELECT 
                    RowNum 
                FROM 
                    PaisOrdenado 
                WHERE 
                    NombrePais = @NombrePais";

            int position = conn.ExecuteScalar<int>(positionQuery, new { NombrePais = nombrePais });
            return (int)Math.Ceiling((decimal)position / pageSize);

        }
    }
}
