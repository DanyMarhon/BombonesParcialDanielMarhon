using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Entidades.Enumeraciones;
using Bombones.Servicios.Intefaces;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosProvinciasEstados : IServiciosProvinciasEstados
    {
        private readonly IRepositorioProvinciasEstados? _repositorio;
        private readonly string? _cadena;
        public ServiciosProvinciasEstados(IRepositorioProvinciasEstados repositorio,
            string cadena)
        {
            _repositorio = repositorio?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
            _cadena = cadena;

        }

        public void Borrar(int provinciaEstadoId)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio!.Borrar(provinciaEstadoId, conn, tran);
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

        public bool EstaRelacionado(int provinciaEstadoId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.EstaRelacionado(provinciaEstadoId, conn);

            }
        }

        public bool Existe(ProvinciaEstado pe)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.Existe(pe, conn);

            }
        }

        public int GetCantidad(Pais? filtroPais)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetCantidad(conn, filtroPais);

            }
        }



        public List<ProvinciaEstadoListDto> GetLista(int? currentPage, int? pageSize, Orden? orden = Orden.Ninguno, Pais? paisSeleccionado = null)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetLista(conn, currentPage, pageSize, orden,
                    paisSeleccionado);

            }

        }

        public List<ProvinciaEstado> GetListaComboEstados(Pais pais)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetListaComboEstados(pais, conn);

            }
        }

        public int GetPaginaPorRegistro(string nombreProvinciaEstado, int pageSize)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetPaginaPorRegistro(conn, nombreProvinciaEstado, pageSize);

            }


        }

        public ProvinciaEstado? GetProvinciaEstadoPorId(int provinciaEstadoId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetProvinciaEstadoPorId(provinciaEstadoId, conn);

            }
        }

        public void Guardar(ProvinciaEstado pe)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (pe.ProvinciaEstadoId == 0)
                        {
                            _repositorio!.Agregar(pe, conn, tran);
                        }
                        else
                        {
                            _repositorio!.Editar(pe, conn, tran);
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
    }
}
