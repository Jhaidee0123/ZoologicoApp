namespace Zoologico.API.Dtos;

public class AutenticacionRespuestaDTO
{
    public string Token { get; set; } = string.Empty;

    public DateTime ValidoHasta { get; set; }
}
