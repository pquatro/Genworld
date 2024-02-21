using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class CampanhaService : ICampanhaService
    {
        private ICampanhaRepository _campanhaRepository;
        private readonly IMapper _mapper;
        public CampanhaService(ICampanhaRepository context, IMapper mapper) 
        {
            _campanhaRepository = context;
            _mapper = mapper;
        }

        
        public async Task<IEnumerable<CampanhaDTO>> GetAllAsync()
        {
            var campanhasEntity = await _campanhaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CampanhaDTO>>(campanhasEntity);
        }

        public async Task<CampanhaDTO> GetByIdAsync(int? id)
        {
            var campanhaEntity = await _campanhaRepository.GetByIdAsync(id);
            return _mapper.Map<CampanhaDTO>(campanhaEntity);
        }

        public async Task<CampanhaDTO> CreateAsync(CampanhaDTO entityDTO)
        {
            var campanhaEntity = _mapper.Map<Campanha>(entityDTO);
            await _campanhaRepository.CreateAsync(campanhaEntity);
            return entityDTO;
        }

        public async Task<CampanhaDTO> UpdateAsync(CampanhaDTO entityDTO)
        {
            var campanhaEntity = _mapper.Map<Campanha>(entityDTO);
            await _campanhaRepository.UpdateAsync(campanhaEntity);
            return entityDTO;
        }

        public async Task<CampanhaDTO> RemoveAsync(CampanhaDTO entityDTO)
        {
            var campanhaEntity = _campanhaRepository.GetByIdAsync(entityDTO.id).Result;
            await _campanhaRepository.RemoveAsync(campanhaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _campanhaRepository?.Dispose();
        }
        
    }
}
