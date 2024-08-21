using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioFabricas : IRepositorioFabricas
    {
        public RepositorioFabricas()
        {
             
        }

        public void Agregar(Fabrica fabrica, SqlConnection conn, SqlTransaction tran)
        {
            string insertQuery = @"INSERT INTO Fabricas 
                (NombreFabrica, Direccion, PaisId, ProvinciaEstadoId, CiudadId) 
                VALUES (@NombreFabrica, @Direccion, @PaisId, @ProvinciaEstadoId, @Ciudadid); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, fabrica,tran);
            if (primaryKey > 0)
            {
                fabrica.CiudadId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar Fabrica");
        }

        public void Borrar(int fabricaId, SqlConnection conn, SqlTransaction tran)
        {
            var deleteQuery = @"DELETE FROM Fabricas 
                WHERE FabricaId=@FabricaId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { fabricaId },tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar la fabrica");
            }
        }

        public void Editar(Fabrica fabrica, SqlConnection conn, SqlTransaction tran)
        {
            var updateQuery = @"UPDATE Fabricas
            SET NombreFabrica=@NombreFabrica,
                Direccion=@Direccion,
                PaisId=@PaisId,
                ProvinciaEstadoId=@ProvinciaEstadoId
                CiudadId=@CiudadId WHERE FabricaId=@FabricaId";
            int registrosAfectados = conn.Execute(updateQuery, fabrica,tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar fabrica");
            }

        }

        public bool EstaRelacionado(int fabricaId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT COUNT(*) FROM Bombones 
                WHERE FabricaId=@FabricaId";
            return conn.QuerySingle<int>
                (selectQuery, new { fabricaId }) > 0;
        }

        public bool Existe(Fabrica fabrica, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Fabricas ";
            string condicionalQuery = string.Empty;
            string finalQuery = string.Empty;
            condicionalQuery = fabrica.CiudadId == 0 ?
                " WHERE NombreFabrica=@NombreFabrica " :
                " WHERE NombreFabrica=@NombreFabrica " +
                "AND FabricaId<>@FabricaId";
            finalQuery = string.Concat(selectQuery, condicionalQuery);
            return conn.QuerySingle<int>(finalQuery, fabrica) > 0;
        }

        public int GetCantidad(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = "SELECT COUNT(*) FROM Fabricas";
            return conn.ExecuteScalar<int>(selectQuery);
        }

        public Fabrica? GetFabricaPorId(int fabricaId, SqlConnection conn)
        {
            string selectQuery = @"SELECT FabricaId, NombreFabrica, 
                Direccion,
                PaisId, ProvinciaEstadoId, CiudadId FROM Fabricas 
                WHERE FabricaId=@FabricaId";
            return conn.QuerySingleOrDefault<Fabrica>(
                selectQuery, new {@FabricaId= fabricaId });
        }

        public List<FabricaListDto> GetLista(SqlConnection conn, int? currentPage, int? pageSize, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT f.FabricaId, f.NombreFabrica,
                f.Direccion, p.NombrePais, pe.NombreProvinciaEstado, 
                c.NombreCiudad FROM Fabricas f
                INNER JOIN Paises p ON f.PaisId=p.PaisId INNER JOIN 
                ProvinciasEstados pe ON f.ProvinciaEstadoId=pe.ProvinciaEstadoId 
                INNER JOIN Ciudades c ON  f.CiudadId=c.CiudadId";
            selectQuery += " ORDER BY f.NombreFabrica";
            if (currentPage.HasValue && pageSize.HasValue)
            {
                var offSet = (currentPage.Value - 1) * pageSize;
                selectQuery += $" OFFSET {offSet} ROWS FETCH NEXT {pageSize.Value} ROWS ONLY";
            }

            return conn.Query<FabricaListDto>(selectQuery).ToList();
        }

        public int GetPaginaPorRegistro(SqlConnection conn, string nombreFabrica, int pageSize, SqlTransaction? tran = null)
        {
            var positionQuery = @"
                    WITH FabricaOrdenada AS (
                    SELECT 
                        ROW_NUMBER() OVER (ORDER BY NombreFabrica) AS RowNum,
                        NombreFabrica
                    FROM 
                        Fabricas
                )
                SELECT 
                    RowNum 
                FROM 
                    FabricaOrdenada 
                WHERE 
                    NombreFabrica = @NombreFabrica";

            int position = conn.ExecuteScalar<int>(positionQuery, new { NombreFabrica = nombreFabrica });
            return (int)Math.Ceiling((decimal)position / pageSize);


        }
    }
}
