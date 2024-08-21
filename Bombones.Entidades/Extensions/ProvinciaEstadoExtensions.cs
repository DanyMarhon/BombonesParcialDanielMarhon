using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Extensions
{
    public static class ProvinciaEstadoExtensions
    {
        public static ProvinciaEstadoListDto ToListDto(this ProvinciaEstado pe)
        {
            return new ProvinciaEstadoListDto
            {
                ProvinciaEstadoId = pe.ProvinciaEstadoId,
                NombreProvinciaEstado = pe.NombreProvinciaEstado,
                NombrePais = pe.Pais?.NombrePais??string.Empty
            };
        }
    }
}
