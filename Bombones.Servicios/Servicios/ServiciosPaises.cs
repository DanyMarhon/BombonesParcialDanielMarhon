using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosPaises : IServiciosPaises
    {
        private readonly IRepositorioPaises? _repositorio;
        private readonly string _cadena;
        public ServiciosPaises(IRepositorioPaises? repositorio, string cadena)
        {
            _repositorio = repositorio?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
            _cadena = cadena;
        }

        public void Borrar(int paisId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio!.Borrar(paisId, conn, tran);
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

        public bool EstaRelacionado(int paisId)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.EstaRelacionado(paisId, conn);
            }
        }

        public bool Existe(Pais pais)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.Existe(pais, conn);
            }
        }

        public Pais? GetPaisPorId(int paisId)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.GetPaisPorId(paisId, conn);
            }
        }

        public List<Pais>? GetLista(int? currentPage, int? pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetLista(conn, currentPage, pageSize);
            }
        }


        public void Guardar(Pais pais)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (pais.PaisId == 0)
                        {
                            _repositorio!.Agregar(pais, conn, tran);
                        }
                        else
                        {
                            _repositorio!.Editar(pais, conn, tran);
                        }

                        tran.Commit();//guarda efectivamente
                    }
                    catch (Exception)
                    {
                        tran.Rollback();//tira todo pa tras!!!
                        throw;
                    }
                }
            }
        }


        public int GetCantidad()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetCantidad(conn);
            }

        }

        public int GetPaginaPorRegistro(string nombrePais, int pageSize)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetPaginaPorRegistro(conn,nombrePais,pageSize);
            }
        }
    }
}
