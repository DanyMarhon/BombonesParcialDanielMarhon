using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosTiposDeRellenos : IServiciosTiposDeRellenos
    {
        private readonly IRepositorioTiposDeRellenos? _repositorio;
        private readonly string? _cadena;
        public ServiciosTiposDeRellenos(IRepositorioTiposDeRellenos? repositorio, string? cadena)
        {
            _repositorio = repositorio?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
            _cadena = cadena;
        }

        public bool Existe(TipoDeRelleno tipoDeRelleno)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.Existe(tipoDeRelleno, conn);

            }
        }

        public List<TipoDeRelleno> GetLista()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.GetLista(conn);

            }
        }
        public void Guardar(TipoDeRelleno tipoDeRelleno)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (tipoDeRelleno.TipoDeRellenoId == 0)
                        {
                            _repositorio!.Agregar(tipoDeRelleno, conn, tran);
                        }
                        else
                        {
                            _repositorio!.Editar(tipoDeRelleno, conn, tran);
                        }
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }

                }
            }
        }
        public void Borrar(int tipoDeRellenoId)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio!.Borrar(tipoDeRellenoId, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }

                }
            }
        }

        public bool EstaRelacionado(int tipoDeRellenoId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.EstaRelacionado(tipoDeRellenoId, conn);
            }
        }
    }
}
