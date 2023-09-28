using AutoMapper;
using RestauranteAPI.Context;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;
using RestauranteAPI.Repositories.Interfaces;



namespace RestauranteAPI.Repositories
{
        public class UsuarioRepository : IUsuario
        {
            private readonly ApplicationDbContext _db;

            private readonly IMapper _mapper;

            public UsuarioRepository(ApplicationDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            public async Task<int> Crear(UsuarioDTO usuario)
            {
                var entidad = _mapper.Map<UsuarioDTO, Usuario>(usuario);
                await _db.Usuarios.AddAsync(_mapper.Map<UsuarioDTO, Usuario>(usuario));

                return await _db.SaveChangesAsync();
            }

    }
  
}
