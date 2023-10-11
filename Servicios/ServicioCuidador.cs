using Zoologico.API.Dtos;
using Zoologico.API.Persistencia.Repositorios.Interfaces;
using Zoologico.API.Servicios.Interfaces;

namespace Zoologico.API.Servicios;

public class ServicioCuidador : IServicioCuidador
{
    private readonly IRepositorioCuidador _repositorioCuidador;

    public ServicioCuidador(IRepositorioCuidador repositorioCuidador)
    {
        _repositorioCuidador = repositorioCuidador;
    }

    public async Task RegistrarCondicionesDeAnimal(RegistroCondicionAnimalDTO registroCondicion)
    {
        await _repositorioCuidador.RegistrarCondicionesDeAnimal(registroCondicion.Animal.Id, 
            registroCondicion.ConsultaMedica, 
            registroCondicion.ExamenLaboratorio);
    }
}
