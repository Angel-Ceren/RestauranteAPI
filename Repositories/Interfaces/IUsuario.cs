using RestauranteAPI.DTOs;

namespace RestauranteAPI.Repositories.Interfaces
{
    public interface IUsuario
    {        
        Task<int> Crear(UsuarioDTO usuario);
        Task<UsuarioDTO> Login(UsuarioLogin login);
        string GenerarToken(UsuarioDTO usuario);
    }
}
