using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Extensions
{
    public static class CiudadesExtensions
    {
        public static CiudadListDto ToCiudadListDto(Ciudad ciudad)
        {
            return new CiudadListDto
            {
                CiudadId = ciudad.CiudadId,
                NombreCiudad = ciudad.NombreCiudad,
                NombrePais = ciudad.Pais?.NombrePais ?? string.Empty,
                NombreProvinciaEstado = ciudad.ProvinciaEstado?.NombreProvinciaEstado ?? string.Empty
            };

        }
    }
}
