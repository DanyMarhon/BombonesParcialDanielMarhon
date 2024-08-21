using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioDirecciones : IRepositorioDirecciones
    {
        public int GetDireccionIdIfExists(Direccion direccion, SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT DireccionId FROM Direcciones 
                WHERE Calle = @Calle 
                    AND Altura = @Altura AND Entre1 = @Entre1 
                    AND Entre2 = @Entre2 AND Piso = @Piso AND Depto = @Depto 
                    AND PaisId = @PaisId 
                    AND ProvinciaEstadoId = @ProvinciaEstadoId 
                    AND CiudadId = @CiudadId AND CodPostal = @CodPostal";
            return conn.ExecuteScalar<int>(selectQuery, direccion, tran);

        }

        public void Agregar(Direccion direccion, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            INSERT INTO Direcciones (Calle, Altura, Entre1, Entre2, Piso, Depto, PaisId, ProvinciaEstadoId, CiudadId, CodPostal)
            VALUES (@Calle, @Altura, @Entre1, @Entre2, @Piso, @Depto, @PaisId, @ProvinciaEstadoId, @CiudadId, @CodPostal);
            SELECT CAST(SCOPE_IDENTITY() as int);
        ";
            direccion.DireccionId = conn.Query<int>(query, direccion, tran).Single();
        }

        public Direccion? GetDireccionPorId(int direccionId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM Direcciones WHERE DireccionId = @DireccionId";
            return conn.QuerySingleOrDefault<Direccion>(query, new { DireccionId = direccionId }, tran);
        }

        public List<Direccion> GetDireccionesPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"
            SELECT d.* 
            FROM Direcciones d
            JOIN ClientesDirecciones cd ON d.DireccionId = cd.DireccionId
            WHERE cd.ClienteId = @ClienteId
        ";
            return conn.Query<Direccion>(query, new { ClienteId = clienteId }, tran).ToList();
        }
    }
}

