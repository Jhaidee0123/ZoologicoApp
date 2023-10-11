namespace Zoologico.API.Persistencia.Repositorios.Autenticacion;

public interface IAutenticacionUsuarioRepositorio
{
    Task RegistrarUsuario(string usuario, string email, string password, string nombre, string apellido, string rol, string numeroCelular);

    Task<(string, DateTime)> Autenticar(string username, string password);
}
