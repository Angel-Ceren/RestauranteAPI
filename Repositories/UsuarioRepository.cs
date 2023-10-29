using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestauranteAPI.Context;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;
using RestauranteAPI.Repositories.Interfaces;
using RestauranteAPI.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductoAPI.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        //Agregar constructor despues de agregar estas 2 lineas de codigo, 
        //seleccionar codigo, acciones rapidas, generar constructor
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly TokenSetting _tokenSetting;

        public UsuarioRepository(ApplicationDbContext db, IMapper mapper, IOptions<TokenSetting> tokenSetting)
        {
            _db = db;
            _mapper = mapper;
            _tokenSetting = tokenSetting.Value;
        }

        public async Task<int> Crear(UsuarioDTO usuario)
        {
            var entidad = _mapper.Map<UsuarioDTO, Usuario>(usuario);
            await _db.Usuarios.AddAsync(entidad);

            return await _db.SaveChangesAsync();
        }

        public string GenerarToken(UsuarioDTO usuario)
        {
            var claveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Key));
            var credenciales = new SigningCredentials(claveSimetrica, SecurityAlgorithms.HmacSha256);
            var claimsUsuario = new List<Claim>
            {
                new Claim("id", usuario.ID.ToString()),
                new Claim(ClaimTypes.Name, usuario.Correo),
            };

            var jwt = new JwtSecurityToken(
                issuer: _tokenSetting.Issuer,
                audience: _tokenSetting.Audience,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credenciales,
                claims: claimsUsuario
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<UsuarioDTO> Login(UsuarioLogin login)
        {
            var entidad = await _db.Usuarios.FirstOrDefaultAsync(x => x.Correo == login.Correo && x.Clave == login.Clave);
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return usuario;
        }
    }
}

