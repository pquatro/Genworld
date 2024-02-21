using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class MissaoService : IMissaoService
    {
        private IMissaoRepository _missaoRepository;
        private readonly IMapper _mapper;
        public MissaoService(IMissaoRepository context, IMapper mapper)
        {
            _missaoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MissaoDTO>> GetAllAsync()
        {
            var MissaosEntity = await _missaoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MissaoDTO>>(MissaosEntity);
        }

        public async Task<MissaoDTO> GetByIdAsync(int? id)
        {
            var MissaoEntity = await _missaoRepository.GetByIdAsync(id);
            return _mapper.Map<MissaoDTO>(MissaoEntity);
        }

        public async Task<MissaoDTO> CreateAsync(MissaoDTO entityDTO)
        {
            var MissaoEntity = _mapper.Map<Missao>(entityDTO);
            await _missaoRepository.CreateAsync(MissaoEntity);
            return entityDTO;
        }

        public async Task<MissaoDTO> UpdateAsync(MissaoDTO entityDTO)
        {
            var MissaoEntity = _mapper.Map<Missao>(entityDTO);
            await _missaoRepository.UpdateAsync(MissaoEntity);
            return entityDTO;
        }

        public async Task<MissaoDTO> RemoveAsync(MissaoDTO entityDTO)
        {
            var MissaoEntity = _missaoRepository.GetByIdAsync(entityDTO.id).Result;
            await _missaoRepository.RemoveAsync(MissaoEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _missaoRepository?.Dispose();
        }

    }
}



