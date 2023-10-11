using Zoologico.API.Persistencia.Modelos;
using Zoologico.API.Persistencia.Repositorios.Interfaces;

namespace Zoologico.API.Persistencia.Repositorios;

public class RepositorioCuidador : IRepositorioCuidador
{
    private readonly ApplicationDbContext _contexto;

    public RepositorioCuidador(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task RegistrarCondicionesDeAnimal(Guid animalId, ConsultaMedica consultaMedica, ExamenLaboratorio examenLaboratorio)
    {
        var animal = _contexto.Animales.FirstOrDefault(a => a.Id == animalId);

        if (consultaMedica is not null && animal is not null)
        {
            animal.ConsultasMedicas.ToList().Add(consultaMedica);

            animal.ExamenesLaboratorio.ToList().Add(examenLaboratorio);

            await _contexto.SaveChangesAsync();
        }
    }
}
