namespace Zoologico.API.Persistencia.Modelos;

public class ConsultaMedica : ModeloBase
{
    public DateTime Fecha { get; set; }
    public string NombreProfesional { get; set; } = string.Empty;
    public string Observaciones { get; set; } = string.Empty;
    public string Diagnostico { get; set; } = string.Empty;
    public string Tratamiento { get; set; } = string.Empty;
    public string Evolucion { get; set; } = string.Empty;
    public int AnimalId { get; set; }
    public Animal Animal { get; set; } = new Animal();
}
