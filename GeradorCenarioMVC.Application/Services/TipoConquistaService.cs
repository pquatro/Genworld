using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class TipoConquistaService : ITipoConquistaService
    {
        private ITipoConquistaRepository _tipoConquistaRepository;
        private readonly IMapper _mapper;
        public TipoConquistaService(ITipoConquistaRepository context, IMapper mapper)
        {
            _tipoConquistaRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TipoConquistaDTO>> GetAllAsync()
        {			
			var TipoConquistasEntity = await _tipoConquistaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoConquistaDTO>>(TipoConquistasEntity);
        }

        public async Task<TipoConquistaDTO> GetByIdAsync(int? id)
        {
            var TipoConquistaEntity = await _tipoConquistaRepository.GetByIdAsync(id);
            return _mapper.Map<TipoConquistaDTO>(TipoConquistaEntity);
        }

        public async Task<TipoConquistaDTO> CreateAsync(TipoConquistaDTO entityDTO)
        {
            var TipoConquistaEntity = _mapper.Map<TipoConquista>(entityDTO);
            await _tipoConquistaRepository.CreateAsync(TipoConquistaEntity);
            return entityDTO;
        }

        public async Task<TipoConquistaDTO> UpdateAsync(TipoConquistaDTO entityDTO)
        {
            var TipoConquistaEntity = _mapper.Map<TipoConquista>(entityDTO);
            await _tipoConquistaRepository.UpdateAsync(TipoConquistaEntity);
            return entityDTO;
        }

        public async Task<TipoConquistaDTO> RemoveAsync(TipoConquistaDTO entityDTO)
        {
            var TipoConquistaEntity = _tipoConquistaRepository.GetByIdAsync(entityDTO.id).Result;
            await _tipoConquistaRepository.RemoveAsync(TipoConquistaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _tipoConquistaRepository?.Dispose();
        }

    }
}






