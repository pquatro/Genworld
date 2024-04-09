using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class GeneroService : IGeneroService
    {
        private IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;
        public GeneroService(IGeneroRepository context, IMapper mapper)
        {
            _generoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<GeneroDTO>> GetAllAsync()
        {
            var GeneroEntity = await _generoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GeneroDTO>>(GeneroEntity);
        }

        public async Task<GeneroDTO> GetByIdAsync(int? id)
        {
            var GeneroEntity = await _generoRepository.GetByIdAsync(id);
            return _mapper.Map<GeneroDTO>(GeneroEntity);
        }

        public async Task<GeneroDTO> CreateAsync(GeneroDTO entityDTO)
        {
            var GeneroEntity = _mapper.Map<Genero>(entityDTO);
            await _generoRepository.CreateAsync(GeneroEntity);
            return entityDTO;
        }

        public async Task<GeneroDTO> UpdateAsync(GeneroDTO entityDTO)
        {
            var GeneroEntity = _mapper.Map<Genero>(entityDTO);
            await _generoRepository.UpdateAsync(GeneroEntity);
            return entityDTO;
        }

        public async Task<GeneroDTO> RemoveAsync(GeneroDTO entityDTO)
        {
            var GeneroEntity = _generoRepository.GetByIdAsync(entityDTO.id).Result;
            await _generoRepository.RemoveAsync(GeneroEntity);
            return entityDTO;
        }

        public void Dispose()
        {
			_generoRepository?.Dispose();
        }

    }
}