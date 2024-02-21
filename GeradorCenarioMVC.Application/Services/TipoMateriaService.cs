using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class TipoMateriaService : ITipoMateriaService
    {
        private ITipoMateriaRepository _tipoMateriaRepository;
        private readonly IMapper _mapper;
        public TipoMateriaService(ITipoMateriaRepository context, IMapper mapper)
        {
            _tipoMateriaRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TipoMateriaDTO>> GetAllAsync()
        {
            var TipoMateriasEntity = await _tipoMateriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TipoMateriaDTO>>(TipoMateriasEntity);
        }

        public async Task<TipoMateriaDTO> GetByIdAsync(int? id)
        {
            var TipoMateriaEntity = await _tipoMateriaRepository.GetByIdAsync(id);
            return _mapper.Map<TipoMateriaDTO>(TipoMateriaEntity);
        }

        public async Task<TipoMateriaDTO> CreateAsync(TipoMateriaDTO entityDTO)
        {
            var TipoMateriaEntity = _mapper.Map<TipoMateria>(entityDTO);
            await _tipoMateriaRepository.CreateAsync(TipoMateriaEntity);
            return entityDTO;
        }

        public async Task<TipoMateriaDTO> UpdateAsync(TipoMateriaDTO entityDTO)
        {
            var TipoMateriaEntity = _mapper.Map<TipoMateria>(entityDTO);
            await _tipoMateriaRepository.UpdateAsync(TipoMateriaEntity);
            return entityDTO;
        }

        public async Task<TipoMateriaDTO> RemoveAsync(TipoMateriaDTO entityDTO)
        {
            var TipoMateriaEntity = _tipoMateriaRepository.GetByIdAsync(entityDTO.id).Result;
            await _tipoMateriaRepository.RemoveAsync(TipoMateriaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _tipoMateriaRepository?.Dispose();
        }

    }
}







