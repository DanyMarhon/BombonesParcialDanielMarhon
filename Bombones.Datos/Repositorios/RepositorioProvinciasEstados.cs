using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioProvinciasEstados : IRepositorioProvinciasEstados
    {
        public RepositorioProvinciasEstados()
        {
        }

        public void Agregar(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran)
        {
            string insertQuery = @"INSERT INTO ProvinciasEstados 
                (NombreProvinciaEstado, PaisId) 
                VALUES (@NombreProvinciaEstado, @PaisId); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, pe, tran);
            if (primaryKey > 0)
            {
                pe.ProvinciaEstadoId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar Prov./Estado");
        }

        public void Borrar(int provinciaEstadoId, SqlConnection conn, SqlTransaction? tran)
        {
            var deleteQuery = @"DELETE FROM ProvinciasEstados 
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";
            //TODO:Modificar este método
            int registrosAfectados = conn
                .Execute(deleteQuery, new { provinciaEstadoId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar la prov/estado");
            }
        }

        public void Editar(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran)
        {
            var updateQuery = @"UPDATE ProvinciasEstados 
            SET NombreProvinciaEstado=@NombreProvinciaEstado,
                PaisId=@PaisId
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";
            //TODO:Ver otra forma
            int registrosAfectados = conn.Execute(updateQuery, pe, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar prov/estado");
            }

        }

        public bool EstaRelacionado(int provinciaEstadoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM Ciudades 
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";
            return conn.QuerySingle<int>
                (selectQuery, new { provinciaEstadoId }, tran) > 0;
        }

        public bool Existe(ProvinciaEstado pe, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM ProvinciasEstados ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = pe.ProvinciaEstadoId == 0 ?
                " WHERE NombreProvinciaEstado=@NombreProvinciaEstado AND PaisId=@PaisId" :
                " WHERE NombreProvinciaEstado=@NombreProvinciaEstado AND PaisId=@PaisId " +
                "AND ProvinciaEstadoId<>@ProvinciaEstadoId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, pe) > 0;
        }

        public int GetCantidad(SqlConnection conn, Pais? pais = null, SqlTransaction? tran = null)
        {
            var query = "SELECT COUNT(*) FROM ProvinciasEstados";
            if (pais != null)
            {
                query += " WHERE PaisId = @PaisId";
                return conn.ExecuteScalar<int>(query, new { PaisId = pais.PaisId });
            }
            return conn.ExecuteScalar<int>(query);
        }

        public List<ProvinciaEstadoListDto> GetLista(
            SqlConnection conn,
            int? currentPage,
            int? pageSize,
            Orden? orden = Orden.Ninguno,
            Pais? pais = null,
            SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT pe.ProvinciaEstadoId, 
                        pe.NombreProvinciaEstado,
                        p.NombrePais 
                        FROM ProvinciasEstados pe
                        INNER JOIN Paises p ON pe.PaisId = p.PaisId";
            
            List<string> conditions = new List<string>();

            if(pais != null)
            {
                conditions.Add("pe.PaisId=@paisId");
            }

            if (conditions.Any())
            {
                selectQuery +=" WHERE "+ string.Join(" AND ", conditions);
            }
            string orderBy=string.Empty;

            switch (orden)
            {
                case Orden.Ninguno:
                    orderBy = " ORDER BY pe.ProvinciaEstadoId ";
                    break;
                case Orden.PaisAZ:
                    orderBy = " ORDER BY p.NombrePais ";

                    break;
                case Orden.PaisZA:
                    orderBy = " ORDER BY p.NombrePais DESC ";

                    break;
                case Orden.ProvinciaEstadoAZ:
                    orderBy = " ORDER BY pe.NombreProvinciaEstado ";

                    break;
                default:
                    orderBy = " ORDER BY pe.NombreProvinciaEstado DESC ";

                    break;

            }
            selectQuery += orderBy;
            //if(orden==Orden.ProvinciaEstadoAZ || orden == null)
            //{
            //    selectQuery += " ORDER BY pe.NombreProvinciaEstado ";
            //}

            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return conn.Query<ProvinciaEstadoListDto>(selectQuery, new { PaisId = pais?.PaisId }).ToList();
        }

        public List<ProvinciaEstado> GetListaComboEstados(Pais pais, SqlConnection conn,
            SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT ProvinciaEstadoId,
                NombreProvinciaEstado, PaisId 
                FROM ProvinciasEstados 
                WHERE PaisId=@PaisId 
                ORDER BY NombreProvinciaEstado";
            return conn.Query<ProvinciaEstado>(selectQuery,
                new { @PaisId = pais.PaisId }).ToList();

        }

        public int GetPaginaPorRegistro(SqlConnection conn, string nombreProvinciaEstado, int pageSize,  SqlTransaction? tran = null)
        {
            var positionQuery = @"
                    WITH EstadoOrdenado AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY NombreProvinciaEstado) AS RowNum,
                        NombreProvinciaEstado
                    FROM 
                        ProvinciasEstados
                )
                SELECT 
                    RowNum 
                FROM 
                    EstadoOrdenado 
                WHERE 
                    NombreProvinciaEstado = @NombreProvinciaEstado";

            int position = conn.ExecuteScalar<int>(positionQuery, new { @NombreProvinciaEstado=nombreProvinciaEstado });
            return (int)Math.Ceiling((decimal)position / pageSize);

        }

        public ProvinciaEstado? GetProvinciaEstadoPorId(int provinciaEstadoId, SqlConnection conn,
            SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT ProvinciaEstadoId, 
                NombreProvinciaEstado, PaisId FROM ProvinciasEstados 
                WHERE ProvinciaEstadoId=@ProvinciaEstadoId";

            return conn.QueryFirstOrDefault<ProvinciaEstado>(selectQuery,
                new { provinciaEstadoId });
        }
    }
}
