namespace Zoologico.API.Persistencia.Modelos;

public abstract class ModeloBase
{
    public Guid Id { get; protected set; }

    public DateTime CreadoEn { get; protected set; }
}
