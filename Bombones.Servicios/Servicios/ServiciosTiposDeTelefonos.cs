using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosTiposDeTelefonos : IServiciosTiposDeTelefonos
    {
        private readonly IRepositorioTiposDeTelefonos _repositorio;
        private readonly string _cadena;
        public ServiciosTiposDeTelefonos(IRepositorioTiposDeTelefonos repositorio, string cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }

        public List<TipoTelefono> GetLista()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetLista(conn);
            }
        }
    }
}
