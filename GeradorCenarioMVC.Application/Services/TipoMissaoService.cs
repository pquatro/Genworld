using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class TipoMissaoService : ITipoMissaoService
    {
        private ITipoMissaoRepository _tipoMissaoRepository;
        private readonly IMapper _mapper;
        public TipoMissaoService(ITipoMissaoRepository context, IMapper mapper)
        {
            _tipoMissaoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TipoMissaoDTO>> GetAllAsync()
        {
            var TipoMissaosEntity = await _tipoMissaoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoMissaoDTO>>(TipoMissaosEntity);
        }

        public async Task<TipoMissaoDTO> GetByIdAsync(int? id)
        {
            var TipoMissaoEntity = await _tipoMissaoRepository.GetByIdAsync(id);
            return _mapper.Map<TipoMissaoDTO>(TipoMissaoEntity);
        }

        public async Task<TipoMissaoDTO> CreateAsync(TipoMissaoDTO entityDTO)
        {
            var TipoMissaoEntity = _mapper.Map<TipoMissao>(entityDTO);
            await _tipoMissaoRepository.CreateAsync(TipoMissaoEntity);
            return entityDTO;
        }

        public async Task<TipoMissaoDTO> UpdateAsync(TipoMissaoDTO entityDTO)
        {
            var TipoMissaoEntity = _mapper.Map<TipoMissao>(entityDTO);
            await _tipoMissaoRepository.UpdateAsync(TipoMissaoEntity);
            return entityDTO;
        }

        public async Task<TipoMissaoDTO> RemoveAsync(TipoMissaoDTO entityDTO)
        {
            var TipoMissaoEntity = _tipoMissaoRepository.GetByIdAsync(entityDTO.id).Result;
            await _tipoMissaoRepository.RemoveAsync(TipoMissaoEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _tipoMissaoRepository?.Dispose();
        }

    }
}








