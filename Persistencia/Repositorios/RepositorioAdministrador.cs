using Microsoft.EntityFrameworkCore;
using Zoologico.API.Persistencia.Modelos;
using Zoologico.API.Persistencia.Repositorios.Interfaces;

namespace Zoologico.API.Persistencia.Repositorios;

public class RepositorioAdministrador : IRepositorioAdministrador
{
    private readonly ApplicationDbContext _contexto;

    public RepositorioAdministrador(ApplicationDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task AsignarAnimarACuidador(Animal animal, Guid cuidadorId)
    {
        var cuidador = _contexto.Users.FirstOrDefault(c => c.Id == cuidadorId.ToString());

        if (cuidador != null)
        {
            await _contexto.Animales.AddAsync(animal);

            animal.Cuidador = cuidador;

            cuidador.AnimalesACargo.ToList().Add(animal);

            await _contexto.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Animal>> ObtenerReporteDeAnimales()
    {
        return await _contexto.Animales
            .Include(s => s.ConsultasMedicas)
            .Include(c => c.ExamenesLaboratorio)
            .ToListAsync();
    }

    public async Task<IEnumerable<Usuario>> ObtenerReporteDeCuidadores(IEnumerable<string> ids)
    {
        return await _contexto.Users
            .Where(u => ids.Contains(u.Id))
            .Include(a => a.AnimalesACargo)
            .ToListAsync();
    }
}
