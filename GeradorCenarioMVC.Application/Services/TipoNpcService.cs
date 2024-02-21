using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class TipoNpcService : ITipoNpcService
    {
        private ITipoNpcRepository _tipoNpcRepository;
        private readonly IMapper _mapper;
        public TipoNpcService(ITipoNpcRepository context, IMapper mapper)
        {
            _tipoNpcRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TipoNpcDTO>> GetAllAsync()
        {
            var TipoNpcsEntity = await _tipoNpcRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoNpcDTO>>(TipoNpcsEntity);
        }

        public async Task<TipoNpcDTO> GetByIdAsync(int? id)
        {
            var TipoNpcEntity = await _tipoNpcRepository.GetByIdAsync(id);
            return _mapper.Map<TipoNpcDTO>(TipoNpcEntity);
        }

        public async Task<TipoNpcDTO> CreateAsync(TipoNpcDTO entityDTO)
        {
            var TipoNpcEntity = _mapper.Map<TipoNpc>(entityDTO);
            await _tipoNpcRepository.CreateAsync(TipoNpcEntity);
            return entityDTO;
        }

        public async Task<TipoNpcDTO> UpdateAsync(TipoNpcDTO entityDTO)
        {
            var TipoNpcEntity = _mapper.Map<TipoNpc>(entityDTO);
            await _tipoNpcRepository.UpdateAsync(TipoNpcEntity);
            return entityDTO;
        }

        public async Task<TipoNpcDTO> RemoveAsync(TipoNpcDTO entityDTO)
        {
            var TipoNpcEntity = _tipoNpcRepository.GetByIdAsync(entityDTO.id).Result;
            await _tipoNpcRepository.RemoveAsync(TipoNpcEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _tipoNpcRepository?.Dispose();
        }

    }
}









