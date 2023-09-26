using AutoMapper;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;

namespace RestauranteAPI.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Entidad --> DTO
            CreateMap<Usuario, UsuarioDTO>();

            // DTO --> entidad
            CreateMap<UsuarioDTO, Usuario>();

        }
    }
}
