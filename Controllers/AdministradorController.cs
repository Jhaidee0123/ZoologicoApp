using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoologico.API.Dtos;
using Zoologico.API.Persistencia.Modelos;
using Zoologico.API.Servicios.Interfaces;

namespace Zoologico.API.Controllers;

public class AdministradorController : ControllerBase
{
    private readonly IServicioAdministrador _servicioAdministrador;

    public AdministradorController(IServicioAdministrador servicioAdministrador)
    {
        _servicioAdministrador = servicioAdministrador;
    }

    [Authorize(Roles = RolesUsuario.Administrador)]
    [HttpPost("asignar-animal")]
    public async Task<IActionResult> AsignarAnimarACuidador([FromBody]AsignarAnimalDTO dto) 
    {
        await _servicioAdministrador.AsignarAnimarACuidador(dto.Animal, dto.CuidadorId);
        return Ok();
    }

    [Authorize(Roles = RolesUsuario.Administrador)]
    [HttpGet("reporte-cuidadores")]
    public async Task<IEnumerable<CuidadorDTO>> ObtenerReporteDeCuidadores()
    {
        return await _servicioAdministrador.ObtenerReporteDeCuidadores();
    }

    [Authorize(Roles = RolesUsuario.Administrador)]
    [HttpGet("reporte-animales")]
    public async Task<IActionResult> ObtenerReporteDeAnimales()
    {
        return Ok(await _servicioAdministrador.ObtenerReporteDeAnimales());
    }
}
