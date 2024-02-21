using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class StatusMissaoService : IStatusMissaoService
    {
        private IStatusMissaoRepository _statusMissaoRepository;
        private readonly IMapper _mapper;
        public StatusMissaoService(IStatusMissaoRepository context, IMapper mapper)
        {
            _statusMissaoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<StatusMissaoDTO>> GetAllAsync()
        {
            var StatusMissaosEntity = await _statusMissaoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StatusMissaoDTO>>(StatusMissaosEntity);
        }

        public async Task<StatusMissaoDTO> GetByIdAsync(int? id)
        {
            var StatusMissaoEntity = await _statusMissaoRepository.GetByIdAsync(id);
            return _mapper.Map<StatusMissaoDTO>(StatusMissaoEntity);
        }

        public async Task<StatusMissaoDTO> CreateAsync(StatusMissaoDTO entityDTO)
        {
            var StatusMissaoEntity = _mapper.Map<StatusMissao>(entityDTO);
            await _statusMissaoRepository.CreateAsync(StatusMissaoEntity);
            return entityDTO;
        }

        public async Task<StatusMissaoDTO> UpdateAsync(StatusMissaoDTO entityDTO)
        {
            var StatusMissaoEntity = _mapper.Map<StatusMissao>(entityDTO);
            await _statusMissaoRepository.UpdateAsync(StatusMissaoEntity);
            return entityDTO;
        }

        public async Task<StatusMissaoDTO> RemoveAsync(StatusMissaoDTO entityDTO)
        {
            var StatusMissaoEntity = _statusMissaoRepository.GetByIdAsync(entityDTO.id).Result;
            await _statusMissaoRepository.RemoveAsync(StatusMissaoEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _statusMissaoRepository?.Dispose();
        }

    }
}




