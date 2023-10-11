using Zoologico.API.Persistencia.Modelos;

namespace Zoologico.API.Persistencia.Repositorios.Interfaces;

public interface IRepositorioAdministrador
{
    Task AsignarAnimarACuidador(Animal animal, Guid cuidadorId);

    Task<IEnumerable<Usuario>> ObtenerReporteDeCuidadores(IEnumerable<string> ids);

    Task<IEnumerable<Animal>> ObtenerReporteDeAnimales();
}
