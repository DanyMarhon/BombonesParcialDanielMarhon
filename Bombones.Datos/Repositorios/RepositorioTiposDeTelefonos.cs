using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioTiposDeTelefonos : IRepositorioTiposDeTelefonos
    {
        public RepositorioTiposDeTelefonos()
        {

        }
        public List<TipoTelefono> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT TipoTelefonoId, Descripcion FROM TiposTelefonos
                    ORDER BY Descripcion";


            return conn.Query<TipoTelefono>(selectQuery).ToList();

        }

    }
}
