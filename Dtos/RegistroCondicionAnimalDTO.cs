using Zoologico.API.Persistencia.Modelos;

namespace Zoologico.API.Dtos;

public class RegistroCondicionAnimalDTO
{
    public Animal Animal { get; set; } = new Animal();

    public ConsultaMedica ConsultaMedica { get; set; } = new ConsultaMedica();

    public ExamenLaboratorio ExamenLaboratorio { get; set; } = new ExamenLaboratorio();
}
