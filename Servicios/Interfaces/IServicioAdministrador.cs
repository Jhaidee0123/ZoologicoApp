using Zoologico.API.Dtos;
using Zoologico.API.Persistencia.Modelos;

namespace Zoologico.API.Servicios.Interfaces;

public interface IServicioAdministrador
{
    Task AsignarAnimarACuidador(Animal animal, Guid cuidadorId);

    Task<IEnumerable<CuidadorDTO>> ObtenerReporteDeCuidadores();

    Task<IEnumerable<Animal>> ObtenerReporteDeAnimales();
}
