using Bombones.Entidades.Dtos;
using Bombones.Entidades.Entidades;

namespace Bombones.Entidades.Extensions
{
    public static class FabricaExtensions
    {
        public static FabricaListDto ToFabricaListDto(Fabrica fabrica)
        {
            return new FabricaListDto
            {
                FabricaId = fabrica.FabricaId,
                NombreFabrica = fabrica.NombreFabrica,
                NombreCiudad = fabrica.Ciudad?.NombreCiudad??string.Empty,
                NombrePais = fabrica.Pais?.NombrePais ?? string.Empty,
                NombreProvinciaEstado = fabrica.ProvinciaEstado?.NombreProvinciaEstado ?? string.Empty
            };

        }

    }
}
