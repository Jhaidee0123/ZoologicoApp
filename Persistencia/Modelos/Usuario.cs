using Microsoft.AspNetCore.Identity;

namespace Zoologico.API.Persistencia.Modelos;

public class Usuario : IdentityUser
{
    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    public string NumeroCelular = string.Empty;

    public IEnumerable<Animal> AnimalesACargo { get; set; } = new List<Animal>();
}
