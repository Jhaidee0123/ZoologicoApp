using Microsoft.AspNetCore.Identity;
using Zoologico.API.Dtos;
using Zoologico.API.Persistencia.Modelos;
using Zoologico.API.Persistencia.Repositorios.Interfaces;
using Zoologico.API.Servicios.Interfaces;

namespace Zoologico.API.Servicios;

public class ServicioAdministrador : IServicioAdministrador
{
    private readonly IRepositorioAdministrador _repositorioAdministrador;
    private readonly UserManager<Usuario> _usuarioManager;

    public ServicioAdministrador(IRepositorioAdministrador repositorioAdministrador, UserManager<Usuario> usuarioManager)
    {
        _repositorioAdministrador = repositorioAdministrador;
        _usuarioManager = usuarioManager;
    }

    public async Task AsignarAnimarACuidador(Animal animal, Guid cuidadorId)
    {
        await _repositorioAdministrador.AsignarAnimarACuidador(animal, cuidadorId);
    }

    public async Task<IEnumerable<Animal>> ObtenerReporteDeAnimales()
    {
        return await _repositorioAdministrador.ObtenerReporteDeAnimales();
    }

    public async Task<IEnumerable<CuidadorDTO>> ObtenerReporteDeCuidadores()
    {
        var usuarios = await _usuarioManager.GetUsersInRoleAsync(RolesUsuario.Cuidador);

        var cuidadores = await _repositorioAdministrador.ObtenerReporteDeCuidadores(usuarios.Select(c => c.Id));
        return cuidadores.Select(c => new CuidadorDTO {
            Nombre = c.Nombre,
            Apellido = c.Apellido,
            AnimalesACargo = c.AnimalesACargo.ToList(),
            Id = Guid.Parse(c.Id),
            NumeroCelular = c.NumeroCelular
        });
    }
}
