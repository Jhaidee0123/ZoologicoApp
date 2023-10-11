namespace Zoologico.API.Dtos;

public class AnimalDTO
{
    public string Especie { get; set; } = string.Empty;
    public string Habitat { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string TipoComida { get; set; } = string.Empty;
    public string NecesidadesAseo { get; set; } = string.Empty;
    public string NecesidadesAseoHabitat { get; set; } = string.Empty;
    public double? Peso { get; set; }
    public string Vacunas { get; set; } = string.Empty;
    public string Alimentacion { get; set; } = string.Empty;
    public string Alergias { get; set; } = string.Empty;
    public string Medicamentos { get; set; } = string.Empty;
    public string OtrosDatos { get; set; } = string.Empty;
    public Guid CuidadorId { get; set; }
}
