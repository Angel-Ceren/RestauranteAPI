using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestauranteAPI.Context;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;
using RestauranteAPI.Repositories.Interfaces;
using RestauranteAPI.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestauranteAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        private readonly TokenSetting _tokenSetting;

        public UsuarioRepository(ApplicationDbContext db, IMapper mapper, TokenSetting tokenSetting)
        {
            _db = db;
            _mapper = mapper;
            _tokenSetting = tokenSetting;
        }

        public async Task<int> Crear(UsuarioDTO usuario)
        {
            var entidad = _mapper.Map<UsuarioDTO, Usuario>(usuario);
            await _db.Usuarios.AddAsync(_mapper.Map<UsuarioDTO, Usuario>(usuario));

            return await _db.SaveChangesAsync();
        }

        public string GenerarToken(UsuarioDTO usuario)
        {
            var claveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.key));
            var credenciales = new SigningCredentials(claveSimetrica, SecurityAlgorithms.HmacSha256);
            var claimUsuaio = new List<Claim>
            {
                new Claim("id", usuario.ID.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nombre),
            };

            var jwt = new JwtSecurityToken(
                issuer: _tokenSetting.Issuer,
                audience: _tokenSetting.Audience,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credenciales,
                claims: claimUsuaio
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<UsuarioDTO> Login(UsuarioLogin login)
        {
            var entidad = await _db.Usuarios.FirstOrDefaultAsync(x => x.Nombre == login.Nombre && x.Clave == login.Clave);
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return usuario;
        }

        public async Task<ICollection<UsuarioDTO>> Usuarios()
        {
            var entidades = await _db.Usuarios.ToListAsync();

            var usuarios = _mapper.Map<ICollection<Usuario>, ICollection<UsuarioDTO>>(entidades);

            return usuarios;
        }

    }

}
