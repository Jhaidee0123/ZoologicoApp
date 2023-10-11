using Zoologico.API.Persistencia.Modelos;

namespace Zoologico.API.Persistencia.Repositorios.Interfaces;

public interface IRepositorioCuidador
{
    Task RegistrarCondicionesDeAnimal(Guid animalId, ConsultaMedica consultaMedica, ExamenLaboratorio examenLaboratorio);
}
