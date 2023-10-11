using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Zoologico.API.Dtos;
using Zoologico.API.Persistencia.Modelos;
using Zoologico.API.Servicios.Interfaces;

namespace Zoologico.API.Controllers;

[Route("api/[controller]")]
[EnableCors("SPA")]
[ApiController]
public class CuidadorController : ControllerBase
{
    private readonly IServicioCuidador _servicioCuidador;

    public CuidadorController(IServicioCuidador servicioCuidador)
    {
        _servicioCuidador = servicioCuidador;
    }

    [Authorize(Roles = RolesUsuario.Cuidador)]
    [HttpPost("registrar-condiciones-animal")]
    public async Task<IActionResult> RegistrarCondicionesDeAnimal([FromBody]RegistroCondicionAnimalDTO condicionAnimalDTO)
    {
        await _servicioCuidador.RegistrarCondicionesDeAnimal(condicionAnimalDTO);
        return Ok();
    }
}
