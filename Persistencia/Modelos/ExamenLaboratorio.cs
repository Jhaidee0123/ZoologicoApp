namespace Zoologico.API.Persistencia.Modelos;

public class ExamenLaboratorio : ModeloBase
{
    public string Resultados { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public int AnimalId { get; set; }
    public Animal Animal { get; set; } = new Animal();
}
