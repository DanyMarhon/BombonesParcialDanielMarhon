using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTelefonos : IRepositorioTelefonos
    {
        public void Agregar(Telefono telefono, SqlConnection conn, SqlTransaction? tran = null)
        {
            var insertQuery = @"
                INSERT INTO Telefonos (Numero)
                    VALUES (@Numero);
                SELECT CAST(SCOPE_IDENTITY() as int);
                    ";
            telefono.TelefonoId = conn.Query<int>(insertQuery, telefono, tran).Single();
        }

        public int GetTelefonoIdIfExist(Telefono telefono, SqlConnection conn, SqlTransaction tran)
        {
            var selectQuery = @"SELECT TelefonoId FROM Telefonos 
                WHERE Numero = @Numero";
            return conn.ExecuteScalar<int>(selectQuery, telefono, tran);

        }

        public Telefono? GetTelefonoPorId(int telefonoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = "SELECT * FROM Telefonos WHERE TelefonoId = @TelefonoId";
            return conn.QuerySingleOrDefault<Telefono>(query,
                new { TelefonoId = telefonoId }, tran);
        }

        public List<Telefono> GetTelefonosPorClienteId(int clienteId, SqlConnection conn, SqlTransaction? tran = null)
        {
            var query = @"SELECT t.* 
                    FROM Telefonos t
                    JOIN ClientesTelefonos ct ON t.TelefonoId = ct.TelefonoId
                    WHERE ct.ClienteId = @ClienteId
                ";
            return conn.Query<Telefono>(query, new { ClienteId = clienteId }, tran).ToList();
        }
    }
}
