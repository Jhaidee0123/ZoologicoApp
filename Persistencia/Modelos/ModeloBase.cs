namespace Zoologico.API.Persistencia.Modelos;

public class ModeloBase
{
    public Guid Id { get; protected set; }

    public DateTime CreadoEn { get; protected set; }

    public DateTime ActualizadoEn { get; protected set; }
}
