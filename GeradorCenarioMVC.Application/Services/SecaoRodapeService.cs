using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class SecaoRodapeService : ISecaoRodapeService
    {
        private ISecaoRodapeRepository _secaoRodapeRepository;
        private readonly IMapper _mapper;
        public SecaoRodapeService(ISecaoRodapeRepository context, IMapper mapper)
        {
            _secaoRodapeRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SecaoRodapeDTO>> GetAllAsync()
        {
            var SecaoRodapesEntity = await _secaoRodapeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SecaoRodapeDTO>>(SecaoRodapesEntity);
        }

        public async Task<SecaoRodapeDTO> GetByIdAsync(int? id)
        {
            var SecaoRodapeEntity = await _secaoRodapeRepository.GetByIdAsync(id);
            return _mapper.Map<SecaoRodapeDTO>(SecaoRodapeEntity);
        }

        public async Task<SecaoRodapeDTO> CreateAsync(SecaoRodapeDTO entityDTO)
        {
            var SecaoRodapeEntity = _mapper.Map<SecaoRodape>(entityDTO);
            await _secaoRodapeRepository.CreateAsync(SecaoRodapeEntity);
            return entityDTO;
        }

        public async Task<SecaoRodapeDTO> UpdateAsync(SecaoRodapeDTO entityDTO)
        {
            var SecaoRodapeEntity = _mapper.Map<SecaoRodape>(entityDTO);
            await _secaoRodapeRepository.UpdateAsync(SecaoRodapeEntity);
            return entityDTO;
        }

        public async Task<SecaoRodapeDTO> RemoveAsync(SecaoRodapeDTO entityDTO)
        {
            var SecaoRodapeEntity = _secaoRodapeRepository.GetByIdAsync(entityDTO.id).Result;
            await _secaoRodapeRepository.RemoveAsync(SecaoRodapeEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _secaoRodapeRepository?.Dispose();
        }

    }
}



