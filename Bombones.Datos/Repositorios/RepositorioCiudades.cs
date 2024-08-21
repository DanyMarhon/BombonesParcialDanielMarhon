using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioCiudades : IRepositorioCiudades
    {
        public RepositorioCiudades()
        {
             
        }

        public void Agregar(Ciudad ciudad, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Ciudades 
                (NombreCiudad, PaisId, ProvinciaEstadoId) 
                VALUES (@NombreCiudad, @PaisId, @ProvinciaEstadoId); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, ciudad,tran);
            if (primaryKey > 0)
            {
                ciudad.CiudadId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar Ciudad");
        }

        public void Borrar(int ciudadId, SqlConnection conn, SqlTransaction tran)
        {
            var deleteQuery = @"DELETE FROM Ciudades 
                WHERE CiudadId=@CiudadId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { ciudadId },tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar la ciudad");
            }
        }

        public void Editar(Ciudad ciudad, SqlConnection conn, SqlTransaction tran)
        {
            var updateQuery = @"UPDATE Ciudades
            SET NombreCiudad=@NombreCiudad,
                PaisId=@PaisId,
                ProvinciaEstadoId=@ProvinciaEstadoId
                WHERE CiudadId=@CiudadId";
            int registrosAfectados = conn.Execute(updateQuery, ciudad,tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar ciudad");
            }

        }

        public bool EstaRelacionado(int ciudadId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM Fabricas 
                WHERE CiudadId=@CiudadId";
            return conn.QuerySingle<int>
                (selectQuery, new { ciudadId }) > 0;
        }

        public bool Existe(Ciudad ciudad, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Ciudades ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = ciudad.CiudadId == 0 ?
                " WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId " :
                " WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId " +
                "AND CiudadId<>@CiudadId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, ciudad) > 0;
        }

        public int GetCantidad(SqlConnection conn, Pais? paisSeleccionado, ProvinciaEstado? provSeleccionada, SqlTransaction? tran = null)
        {
            var selectQuery = "SELECT COUNT(*) FROM Ciudades";
            List<string> conditions= new List<string>();

            if (paisSeleccionado != null)
            {
                conditions.Add(" WHERE PaisId = @PaisId");
               
            }
            if (provSeleccionada != null)
            {
                conditions.Add("ProvinciaEstadoId= @ProvinciaEstadoId");
            }
            if (conditions.Any())
            {
                selectQuery += string.Join(" AND ", conditions);
                return conn.ExecuteScalar<int>(selectQuery, new {@PaisId=paisSeleccionado?.PaisId,
                    @ProvinciaEstadoId=provSeleccionada?.ProvinciaEstadoId
                });

            }
            return conn.ExecuteScalar<int>(selectQuery);
        }

        public Ciudad? GetCiudadPorId(int ciudadId, SqlConnection conn)
        {
            string selectQuery = @"SELECT CiudadId, NombreCiudad, 
                PaisId, ProvinciaEstadoId FROM Ciudades 
                WHERE CiudadId=@CiudadId";
            return conn.QuerySingleOrDefault<Ciudad>(
                selectQuery, new {@CiudadId= ciudadId });
        }


        public List<CiudadListDto> GetLista(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT c.CiudadId, c.NombreCiudad, 
                p.NombrePais, pe.NombreProvinciaEstado FROM Ciudades c
                INNER JOIN Paises p ON c.PaisId=p.PaisId INNER JOIN 
                ProvinciasEstados pe ON c.ProvinciaEstadoId=pe.ProvinciaEstadoId";

            selectQuery += " ORDER BY c.NombreCiudad";
            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }
            return conn.Query<CiudadListDto>(selectQuery).ToList();

        }

        public List<Ciudad> GetListaCombo(SqlConnection conn, Pais paisSeleccionado, ProvinciaEstado provinciaEstado)
        {
            string selectQuery = @"SELECT CiudadId, NombreCiudad, 
                PaisId, ProvinciaEstadoId FROM Ciudades 
                WHERE PaisId=@PaisId AND ProvinciaEstadoId=@ProvinciaEstadoId";
            return conn.Query<Ciudad>(selectQuery, new
            {
                @PaisId = paisSeleccionado.PaisId,
                @ProvinciaEstadoId = provinciaEstado.ProvinciaEstadoId
            }).ToList();
        }

        public int GetPaginaPorRegistro(SqlConnection conn, string nombreCiudad, int pageSize, SqlTransaction? tran = null)
        {
            var positionQuery = @"
                    WITH CiudadOrdenada AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY NombreCiudad) AS RowNum,
                        NombreCiudad
                    FROM 
                        Ciudades
                )
                SELECT 
                    RowNum 
                FROM 
                    CiudadOrdenada 
                WHERE 
                    NombreCiudad = @NombreCiudad";

            int position = conn.ExecuteScalar<int>(positionQuery, new { NombreCiudad = nombreCiudad });
            return (int)Math.Ceiling((decimal)position / pageSize);

        }
    }
}
