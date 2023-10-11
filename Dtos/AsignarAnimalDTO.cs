using Zoologico.API.Persistencia.Modelos;

namespace Zoologico.API.Dtos;

public class AsignarAnimalDTO
{
    public Animal Animal { get; set; } = new Animal();

    public Guid CuidadorId { get; set; }
}
