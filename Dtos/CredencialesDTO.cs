using System.ComponentModel.DataAnnotations;

namespace Zoologico.API.Dtos;

public class CredencialesDTO
{
    [Required(ErrorMessage = "User Name es requerido")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password requerida")]
    public string Password { get; set; } = string.Empty;
}
