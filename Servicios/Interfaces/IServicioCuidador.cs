using Zoologico.API.Dtos;

namespace Zoologico.API.Servicios.Interfaces;

public interface IServicioCuidador
{
    Task RegistrarCondicionesDeAnimal(RegistroCondicionAnimalDTO registroCondicion);
}
