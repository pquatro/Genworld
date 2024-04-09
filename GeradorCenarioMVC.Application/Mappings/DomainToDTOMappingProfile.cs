using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Domain.Entities;

namespace GeradorCenarioMVC.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Campanha, CampanhaDTO>().ReverseMap();            
            CreateMap<Genero, GeneroDTO>().ReverseMap();            
            CreateMap<Imagem, ImagemDTO>().ReverseMap();            
            CreateMap<Sessao, SessaoDTO>().ReverseMap();            
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            
        }
    }
}
