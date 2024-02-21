using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class CenarioService : ICenarioService
    {
        private ICenarioRepository _cenarioRepository;
        private readonly IMapper _mapper;
        public CenarioService(ICenarioRepository context, IMapper mapper)
        {
            _cenarioRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CenarioDTO>> GetAllAsync()
        {
            var CenariosEntity = await _cenarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CenarioDTO>>(CenariosEntity);
        }

        public async Task<CenarioDTO> GetByIdAsync(int? id)
        {
            var CenarioEntity = await _cenarioRepository.GetByIdAsync(id);
            return _mapper.Map<CenarioDTO>(CenarioEntity);
        }

        public async Task<CenarioDTO> CreateAsync(CenarioDTO entityDTO)
        {
            var CenarioEntity = _mapper.Map<Cenario>(entityDTO);
            await _cenarioRepository.CreateAsync(CenarioEntity);
            return entityDTO;
        }

        public async Task<CenarioDTO> UpdateAsync(CenarioDTO entityDTO)
        {
            var CenarioEntity = _mapper.Map<Cenario>(entityDTO);
            await _cenarioRepository.UpdateAsync(CenarioEntity);
            return entityDTO;
        }

        public async Task<CenarioDTO> RemoveAsync(CenarioDTO entityDTO)
        {
            var CenarioEntity = _cenarioRepository.GetByIdAsync(entityDTO.id).Result;
            await _cenarioRepository.RemoveAsync(CenarioEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _cenarioRepository?.Dispose();
        }

    }
}