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
            CreateMap<CategoriaMateria, CategoriaMateriaDTO>().ReverseMap();
            CreateMap<CenarioGenero, CenarioGeneroDTO>().ReverseMap();
            CreateMap<Cenario, CenarioDTO>().ReverseMap();
            CreateMap<Conquista, ConquistaDTO>().ReverseMap();
            CreateMap<Enredo, EnredoDTO>().ReverseMap();
            CreateMap<Galeria, GaleriaDTO>().ReverseMap();
            CreateMap<Grupo, GrupoDTO>().ReverseMap();
            CreateMap<Imagem, ImagemDTO>().ReverseMap();
            CreateMap<Mapa, MapaDTO>().ReverseMap();
            CreateMap<Materia, MateriaDTO>().ReverseMap();
            CreateMap<Missao, MissaoDTO>().ReverseMap();
            CreateMap<Npc, NpcDTO>().ReverseMap();
            CreateMap<Pc, PcDTO>().ReverseMap();
            CreateMap<SecaoCabecalho, SecaoCabecalhoDTO>().ReverseMap();
            CreateMap<SecaoLateral, SecaoLateralDTO>().ReverseMap();
            CreateMap<SecaoRodape, SecaoRodapeDTO>().ReverseMap();
            CreateMap<Sessao, SessaoDTO>().ReverseMap();
            CreateMap<StatusMissao, StatusMissaoDTO>().ReverseMap();
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<TipoConquista, TipoConquistaDTO>().ReverseMap();
            CreateMap<TipoMateria, TipoMateriaDTO>().ReverseMap();
            CreateMap<TipoMissao, TipoMissaoDTO>().ReverseMap();
            CreateMap<TipoNpc, TipoNpcDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            
        }
    }
}
