using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Zoologico.API.Persistencia.Modelos;

namespace Zoologico.API.Persistencia.Repositorios.Autenticacion;

public class AutenticacionUsuarioRepositorio : IAutenticacionUsuarioRepositorio
{
    private readonly UserManager<Usuario> _usuarioManager;
    private readonly RoleManager<IdentityRole> _rolManager;
    private readonly IConfiguration _configuration;

    public AutenticacionUsuarioRepositorio(UserManager<Usuario> usuarioManager, RoleManager<IdentityRole> rolManager, IConfiguration configuration)
    {
        _usuarioManager = usuarioManager;
        _rolManager = rolManager;
        _configuration = configuration;
    }

    public async Task<(string, DateTime)> Autenticar(string username, string password)
    {
        var usuario = await _usuarioManager.FindByNameAsync(username);
        if (usuario is null || !await _usuarioManager.CheckPasswordAsync(usuario, password))
            throw new InvalidOperationException("Credenciales invalidas.");

        var rolesUsuario = await _usuarioManager.GetRolesAsync(usuario);

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, usuario.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var rol in rolesUsuario)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, rol));
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
            _configuration["JWT:ValidIssuer"],
            _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddDays(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256)
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), token.ValidTo);
    }

    public async Task RegistrarUsuario(string usuario, string email, string password, string nombre, string apellido, string rol)
    {
        var usuarioExiste = await _usuarioManager.FindByNameAsync(usuario);
        if (usuarioExiste is not null)
        {
            throw new InvalidOperationException("Este usuario ya existe.");
        }

        var student = new Usuario
        {
            Email = email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = usuario,
            Nombre = nombre,
            Apellido = apellido
        };

        var resultado = await _usuarioManager.CreateAsync(student, password);
        if (!resultado.Succeeded)
        {
            throw new InvalidOperationException("Hubo un error en el registro del usuario");
        }

        if (!await _rolManager.RoleExistsAsync(RolesUsuario.Cuidador))
            await _rolManager.CreateAsync(new IdentityRole(RolesUsuario.Cuidador));
        if (!await _rolManager.RoleExistsAsync(RolesUsuario.Administrador))
            await _rolManager.CreateAsync(new IdentityRole(RolesUsuario.Administrador));
        if (!await _rolManager.RoleExistsAsync(RolesUsuario.Cliente))
            await _rolManager.CreateAsync(new IdentityRole(RolesUsuario.Cliente));

        if (await _rolManager.RoleExistsAsync(rol))
        {
            await _usuarioManager.AddToRoleAsync(student, rol);
        }
    }
}
