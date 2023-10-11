using System.ComponentModel.DataAnnotations;

namespace Zoologico.API.Dtos;

public class RegistrarUsuarioDTO
{
    [Required(ErrorMessage = "Usuario requerido")]
    public string Usuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email requerido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password requerido")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Nombre requerido")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Apellido requerido")]
    public string Apellido { get; set; } = string.Empty;

    [Required(ErrorMessage = "NumeroCelular requerido")]
    public string NumeroCelular { get; set; } = string.Empty;
}
