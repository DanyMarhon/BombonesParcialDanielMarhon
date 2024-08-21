using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTiposDeDirecciones : IRepositorioTiposDeDirecciones
    {

        public List<TipoDireccion> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT TipoDireccionId, Descripcion FROM TiposDirecciones
                    ORDER BY Descripcion";


            return conn.Query<TipoDireccion>(selectQuery).ToList();

        }
    }

}
