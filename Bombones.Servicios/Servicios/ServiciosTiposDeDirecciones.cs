using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosTiposDeDirecciones : IServiciosTiposDeDirecciones
    {
        private readonly IRepositorioTiposDeDirecciones _repositorio;
        private readonly string _cadena;
        public ServiciosTiposDeDirecciones(IRepositorioTiposDeDirecciones repositorio, string cadena)
        {
            _repositorio = repositorio;
            _cadena = cadena;
        }

        public List<TipoDireccion> GetLista()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio.GetLista(conn);
            }
        }
    }
}
