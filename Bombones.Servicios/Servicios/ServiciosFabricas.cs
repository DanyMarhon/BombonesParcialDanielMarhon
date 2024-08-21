using Bombones.Datos.Interfaces;
using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System.Data.SqlClient;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosFabricas : IServiciosFabricas
    {
        private readonly IRepositorioFabricas? _repositorio;
        private readonly string? _cadena;

        public ServiciosFabricas(IRepositorioFabricas? repositorio,
            string? cadena)
        {
            _repositorio = repositorio??throw new ApplicationException("Dependencias no cargadas!!!"); ;
            _cadena = cadena;
        }

        public void Borrar(int fabricaId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio!.Borrar(fabricaId, conn, tran);
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

        public bool EstaRelacionado(int fabricaId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.EstaRelacionado(fabricaId, conn);
            }
        }

        public bool Existe(Fabrica fabrica)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.Existe(fabrica, conn);
            }
        }

        public int GetCantidad(Pais? paisSeleccionado = null,
            ProvinciaEstado? provSeleccionada = null,
            Ciudad? ciudadSeleccionada=null)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!
                    .GetCantidad(conn);
            }
        }

        public Fabrica? GetFabricaPorId(int fabricaId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.GetFabricaPorId(fabricaId, conn);
            }
        }

        public List<FabricaListDto> GetLista(int? currentPage, int? pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetLista(conn, currentPage, pageSize);
            }
        }

        public int GetPaginaPorRegistro(string nombreFabrica, int pageSize)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!
                    .GetPaginaPorRegistro(conn, nombreFabrica, pageSize);
            }
        }

        public void Guardar(Fabrica fabrica)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (fabrica.FabricaId == 0)
                        {
                            _repositorio!.Agregar(fabrica, conn, tran);
                        }
                        else
                        {
                            _repositorio!.Editar(fabrica, conn, tran);
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

    }
}
