using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class SessaoService : ISessaoService
    {
        private ISessaoRepository _sessaoRepository;
        private readonly IMapper _mapper;
        public SessaoService(ISessaoRepository context, IMapper mapper)
        {
            _sessaoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SessaoDTO>> GetAllAsync()
        {
            var SessaosEntity = await _sessaoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SessaoDTO>>(SessaosEntity);
        }

        public async Task<SessaoDTO> GetByIdAsync(int? id)
        {
            var SessaoEntity = await _sessaoRepository.GetByIdAsync(id);
            return _mapper.Map<SessaoDTO>(SessaoEntity);
        }

        public async Task<SessaoDTO> CreateAsync(SessaoDTO entityDTO)
        {
            var SessaoEntity = _mapper.Map<Sessao>(entityDTO);
            await _sessaoRepository.CreateAsync(SessaoEntity);
            return entityDTO;
        }

        public async Task<SessaoDTO> UpdateAsync(SessaoDTO entityDTO)
        {
            var SessaoEntity = _mapper.Map<Sessao>(entityDTO);
            await _sessaoRepository.UpdateAsync(SessaoEntity);
            return entityDTO;
        }

        public async Task<SessaoDTO> RemoveAsync(SessaoDTO entityDTO)
        {
            var SessaoEntity = _sessaoRepository.GetByIdAsync(entityDTO.id).Result;
            await _sessaoRepository.RemoveAsync(SessaoEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _sessaoRepository?.Dispose();
        }

    }
}



