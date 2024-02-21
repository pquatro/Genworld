using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class CenarioGeneroService : ICenarioGeneroService
    {
        private ICenarioGeneroRepository _cenarioGeneroRepository;
        private readonly IMapper _mapper;
        public CenarioGeneroService(ICenarioGeneroRepository context, IMapper mapper)
        {
            _cenarioGeneroRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CenarioGeneroDTO>> GetAllAsync()
        {
            var CenarioGenerosEntity = await _cenarioGeneroRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CenarioGeneroDTO>>(CenarioGenerosEntity);
        }

        public async Task<CenarioGeneroDTO> GetByIdAsync(int? id)
        {
            var CenarioGeneroEntity = await _cenarioGeneroRepository.GetByIdAsync(id);
            return _mapper.Map<CenarioGeneroDTO>(CenarioGeneroEntity);
        }

        public async Task<CenarioGeneroDTO> CreateAsync(CenarioGeneroDTO entityDTO)
        {
            var CenarioGeneroEntity = _mapper.Map<CenarioGenero>(entityDTO);
            await _cenarioGeneroRepository.CreateAsync(CenarioGeneroEntity);
            return entityDTO;
        }

        public async Task<CenarioGeneroDTO> UpdateAsync(CenarioGeneroDTO entityDTO)
        {
            var CenarioGeneroEntity = _mapper.Map<CenarioGenero>(entityDTO);
            await _cenarioGeneroRepository.UpdateAsync(CenarioGeneroEntity);
            return entityDTO;
        }

        public async Task<CenarioGeneroDTO> RemoveAsync(CenarioGeneroDTO entityDTO)
        {
            var CenarioGeneroEntity = _cenarioGeneroRepository.GetByIdAsync(entityDTO.id).Result;
            await _cenarioGeneroRepository.RemoveAsync(CenarioGeneroEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _cenarioGeneroRepository?.Dispose();
        }

    }
}