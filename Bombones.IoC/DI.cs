using Bombones.Datos.Interfaces;
using Bombones.Datos.Repositorios;
using Bombones.Servicios.Intefaces;
using Bombones.Servicios.Servicios;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Bombones.IoC
{
    public static class DI
    {
        public static IServiceProvider ConfigurarServicios()
        {
            var service = new ServiceCollection();

            var cadena = ConfigurationManager
                .ConnectionStrings["MiConexion"].ToString();

            service.AddScoped<IRepositorioPaises, RepositorioPaises>();
            service.AddScoped<IRepositorioTiposDeChocolates, RepositorioTiposDeChocolates>();
            service.AddScoped<IRepositorioTiposDeNueces, RepositorioTiposDeNueces>();
            service.AddScoped<IRepositorioProvinciasEstados, RepositorioProvinciasEstados>();

            service.AddScoped<IRepositorioCiudades, RepositorioCiudades>();
            service.AddScoped<IRepositorioFabricas, RepositorioFabricas>();
            service.AddScoped<IRepositorioBombones, RepositorioBombones>();

            service.AddScoped<IServiciosProvinciasEstados, ServiciosProvinciasEstados>();

            service.AddScoped<IRepositorioClientes, RepositorioClientes>();
            service.AddScoped<IRepositorioDirecciones, RepositorioDirecciones>();
            service.AddScoped<IRepositorioTelefonos, RepositorioTelefonos>();

            service.AddScoped<IRepositorioClientesTelefonos, RepositorioClientesTelefonos>();
            service.AddScoped<IRepositorioClientesDirecciones, RepositorioClientesDirecciones>();

            service.AddScoped<IRepositorioTiposDeDirecciones, RepositorioTiposDeDirecciones>();
            service.AddScoped<IRepositorioTiposDeTelefonos, RepositorioTiposDeTelefonos>();

            service.AddScoped<IServiciosPaises>(sp => {
                var repositorio = new RepositorioPaises();
                return new ServiciosPaises(repositorio, cadena);
            });
            service.AddScoped<IServiciosTiposDeChocolates>(sp => {
                var repositorio = new RepositorioTiposDeChocolates();
                return new ServiciosTiposDeChocolates(repositorio, cadena);
            });

            service.AddScoped<IServiciosTiposDeNueces>(sp =>
            {
                var repositorio = new RepositorioTiposDeNueces();
                return new ServiciosTiposDeNueces(repositorio, cadena);
            });
            service.AddScoped<IServiciosTiposDeRellenos>(sp =>
            {
                var repositorio = new RepositorioTiposDeRellenos();
                return new ServiciosTiposDeRellenos(repositorio, cadena);
            });
            service.AddScoped<IServiciosProvinciasEstados>(sp =>
            {
                var repositorio = new RepositorioProvinciasEstados();
                return new ServiciosProvinciasEstados(repositorio, cadena);
            });

            service.AddScoped<IServiciosCiudades>(sp => {
                var repositorio = new RepositorioCiudades();
                return new ServiciosCiudades(repositorio, cadena);
            });

            service.AddScoped<IServiciosFabricas>(sp => {
                var repositorio = new RepositorioFabricas();
                return new ServiciosFabricas(repositorio, cadena);
            });

            service.AddScoped<IServiciosClientes>(sp =>
            {
                var repositorio = new RepositorioClientes();
                var repositorioDirecciones = new RepositorioDirecciones();
                var repositorioTelefonos = new RepositorioTelefonos();
                var repositorioClientesDirecciones = new RepositorioClientesDirecciones();
                var repositorioClientesTelefonos = new RepositorioClientesTelefonos();
                return new ServiciosClientes(repositorio,
                    repositorioDirecciones,
                    repositorioTelefonos,
                    repositorioClientesDirecciones,
                    repositorioClientesTelefonos,
                    cadena);
            });

            service.AddScoped<IServiciosTiposDeDirecciones>(sp => {
                var repositorio = new RepositorioTiposDeDirecciones();
                return new ServiciosTiposDeDirecciones(repositorio, cadena);
            });

            service.AddScoped<IServiciosTiposDeTelefonos>(sp => {
                var repositorio = new RepositorioTiposDeTelefonos();
                return new ServiciosTiposDeTelefonos(repositorio, cadena);
            });

            service.AddScoped<IServiciosBombones>(sp => {
                var repositorio = new RepositorioBombones();
                return new ServiciosBombones(repositorio, cadena);
            });

            return service.BuildServiceProvider();
        }
    }
}
