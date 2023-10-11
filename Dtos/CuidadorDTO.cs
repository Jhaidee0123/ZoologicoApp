using Zoologico.API.Persistencia.Modelos;

namespace Zoologico.API.Dtos;

public class CuidadorDTO
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;


    public string NumeroCelular = string.Empty;

    public List<Animal> AnimalesACargo = new List<Animal>();
}
