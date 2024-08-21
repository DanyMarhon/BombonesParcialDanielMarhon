using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosTiposDeChocolates : IServiciosTiposDeChocolates
    {
        private readonly IRepositorioTiposDeChocolates? _repositorio;
        private readonly string? _cadena;
        public ServiciosTiposDeChocolates(IRepositorioTiposDeChocolates? repositorio, string? cadena)
        {
            _repositorio = repositorio?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
            _cadena = cadena;
        }

        public bool Existe(TipoDeChocolate tipoDeChocolate)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.Existe(tipoDeChocolate, conn);

            }
        }

        public List<TipoDeChocolate> GetLista()
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetLista(conn);
            }
        }
        public void Guardar(TipoDeChocolate tipoDeChocolate)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (tipoDeChocolate.TipoDeChocolateId == 0)
                        {
                            _repositorio!.Agregar(tipoDeChocolate, conn, tran);
                        }
                        else
                        {
                            _repositorio!.Editar(tipoDeChocolate, conn, tran);
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
        public void Borrar(int tipoDeChocolateId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio!.Borrar(tipoDeChocolateId, conn, tran);
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

        public bool EstaRelacionado(int tipoDeChocolateId)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.EstaRelacionado(tipoDeChocolateId, conn);
            }
        }
    }
}
