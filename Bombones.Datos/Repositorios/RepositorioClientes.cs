using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes

    {
        public RepositorioClientes()
        {

        }

        public void Agregar(Cliente cliente, SqlConnection conn, SqlTransaction? tran)
        {
            string insertQuery = @"INSERT INTO Clientes 
                (Nombres, Apellido, Documento) 
                VALUES (@Nombres, @Apellido, @Documento); 
                SELECT CAST(SCOPE_IDENTITY() as int)";

            int primaryKey = conn.QuerySingle<int>(insertQuery, cliente, tran);
            if (primaryKey > 0)
            {
                cliente.ClienteId = primaryKey;
                return;
            }
            throw new Exception("No se pudo agregar el cliente");
        }

        public void Borrar(int ClienteId, SqlConnection conn, SqlTransaction? tran)
        {
            var deleteQuery = @"DELETE FROM Clientes 
                WHERE ClienteId=@ClienteId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { ClienteId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el cliente");
            }
        }

        public bool Existe(Cliente cliente, SqlConnection conn, SqlTransaction? tran = null)
        {
            try
            {
                string selectQuery = @"SELECT COUNT(*) FROM Clientes ";
                string finalQuery = string.Empty;
                string conditional = string.Empty;
                if (cliente.ClienteId == 0)
                {
                    conditional = "WHERE Documento = @Documento";
                }
                else
                {
                    conditional = @"WHERE Documento = @Documento
                            AND ClienteId<>@ClienteId";
                }
                finalQuery = string.Concat(selectQuery, conditional);
                return conn.QuerySingle<int>(finalQuery, cliente) > 0;

            }
            catch (Exception)
            {

                throw new Exception("No se pudo comprobar si existe el cliente");
            }
        }

        public void Editar(Cliente cliente, SqlConnection conn, SqlTransaction? tran=null)
        {
            var updateQuery = @"UPDATE Clientes
            SET Documento=@Documento,
                Apellido=@Apellido,
                Nombres=@Nombres
            WHERE ClienteId=@ClienteId";
            int registrosAfectados = conn.Execute(updateQuery, cliente, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el cliente");
            }
        }

        public Cliente? GetClientePorId(int clienteId, SqlConnection conn)
        {
            string selectQuery = @"SELECT ClienteId, Documento, Nombres, Apellido 
                FROM Clientes 
                WHERE ClienteId=@ClienteId";
            return conn.QuerySingleOrDefault<Cliente>(
                selectQuery, new { @ClienteId = clienteId });
        }

        public List<ClienteListDto> GetLista(SqlConnection conn, int? pageNumber, int? pageSize, SqlTransaction? tran)
        {
            var offset = (pageNumber - 1) * pageSize;
            var selectQuery = @"SELECT 
                c.ClienteId, 
                c.Documento, 
                c.Apellido,
                c.Nombres,
                d.Calle,
                d.Altura,
                ci.NombreCiudad AS Ciudad,
                pe.NombreProvinciaEstado AS ProvinciaEstado, 
                p.NombrePais AS Pais,
                t.Numero 
            FROM Clientes c
            LEFT JOIN ClientesDirecciones cd ON c.ClienteId = cd.ClienteId
            LEFT JOIN Direcciones d ON cd.DireccionId = d.DireccionId
            LEFT JOIN ClientesTelefonos ct ON c.ClienteId = ct.ClienteId
            LEFT JOIN Telefonos t ON ct.TelefonoId = t.TelefonoId
            LEFT JOIN Paises p ON d.PaisId = p.PaisId
            LEFT JOIN ProvinciasEstados pe ON d.ProvinciaEstadoId = pe.ProvinciaEstadoId
            LEFT JOIN Ciudades ci ON d.CiudadId = ci.CiudadId
            ORDER BY c.ClienteId 
            OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var clientes = new List<ClienteListDto>();
            conn.Query<Cliente, DireccionListDto, Telefono, ClienteListDto>
                (selectQuery,
                    (cliente, direccion, telefono) =>
                    {
                        var clienteDto = clientes
                        .FirstOrDefault(c => c.ClienteId == cliente.ClienteId);
                        if (clienteDto is null)
                        {
                            clienteDto = new ClienteListDto
                            {
                                ClienteId = cliente.ClienteId,
                                Documento = cliente.Documento,
                                NombreCompleto = $"{cliente.Apellido} {cliente.Nombres}",
                                DireccionPrincipal = direccion.ToString(),
                                TelefonoPrincipal = telefono.ToString()
                            };
                            clientes.Add(clienteDto);
                        }
                        return clienteDto;
                    },
                    new { @Offset = offset, @PageSize = pageSize },
                    splitOn: "ClienteId, Calle, Numero",
                    buffered: true
                );
            return clientes;
        }

        public int GetCantidad(SqlConnection conn)
        {
            var selectQuery = "SELECT COUNT(*) FROM Clientes";
            List<string> conditions = new List<string>();

            return conn.ExecuteScalar<int>(selectQuery);

        }
    }
}
