using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Zoologico.API.Dtos;
using Zoologico.API.Persistencia.Modelos;
using Zoologico.API.Persistencia.Repositorios.Autenticacion;

namespace Zoologico.API.Controllers;

[Route("api/[controller]")]
[EnableCors("SPA")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IAutenticacionUsuarioRepositorio _usuarioRepositorio;

    public UsuarioController(IAutenticacionUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    [HttpPost("autenticar")]
    public async Task<IActionResult> Autenticar([FromBody] CredencialesDTO credenciales)
    {
        if (credenciales is null)
        {
            throw new ArgumentNullException(nameof(credenciales));
        }

        var (token, validoHasta) = await _usuarioRepositorio.Autenticar(credenciales.Username, credenciales.Password);

        var respuesta = new AutenticacionRespuestaDTO
        {
            Token = token,
            ValidoHasta = validoHasta
        };

        return Ok(respuesta);
    }

    [Authorize(Roles = RolesUsuario.Administrador)]
    [HttpPost("crear-cuidador")]
    public async Task<IActionResult> CrearCuidador([FromBody] RegistrarUsuarioDTO cuidadorDTO)
    {
        if (cuidadorDTO is null)
        {
            throw new ArgumentNullException(nameof(cuidadorDTO));
        }

        await _usuarioRepositorio.RegistrarUsuario(cuidadorDTO.Usuario,
                                                   cuidadorDTO.Email,
                                                   cuidadorDTO.Password,
                                                   cuidadorDTO.Nombre,
                                                   cuidadorDTO.Apellido, 
                                                   RolesUsuario.Cuidador,
                                                   cuidadorDTO.NumeroCelular);
        return Created("", cuidadorDTO);
    }

    [HttpPost("crear-administrador")]
    public async Task<IActionResult> CrearAdministrador([FromBody] RegistrarUsuarioDTO cuidadorDTO)
    {
        if (cuidadorDTO is null)
        {
            throw new ArgumentNullException(nameof(cuidadorDTO));
        }

        await _usuarioRepositorio.RegistrarUsuario(cuidadorDTO.Usuario,
                                                   cuidadorDTO.Email,
                                                   cuidadorDTO.Password,
                                                   cuidadorDTO.Nombre,
                                                   cuidadorDTO.Apellido,
                                                   RolesUsuario.Administrador,
                                                   cuidadorDTO.NumeroCelular);
        return Created("", cuidadorDTO);
    }
}
