using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class MapaService : IMapaService
    {
        private IMapaRepository _mapaRepository;
        private readonly IMapper _mapper;
        public MapaService(IMapaRepository context, IMapper mapper)
        {
            _mapaRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MapaDTO>> GetAllAsync()
        {
            var MapasEntity = await _mapaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MapaDTO>>(MapasEntity);
        }

        public async Task<MapaDTO> GetByIdAsync(int? id)
        {
            var MapaEntity = await _mapaRepository.GetByIdAsync(id);
            return _mapper.Map<MapaDTO>(MapaEntity);
        }

        public async Task<MapaDTO> CreateAsync(MapaDTO entityDTO)
        {
            var MapaEntity = _mapper.Map<Mapa>(entityDTO);
            await _mapaRepository.CreateAsync(MapaEntity);
            return entityDTO;
        }

        public async Task<MapaDTO> UpdateAsync(MapaDTO entityDTO)
        {
            var MapaEntity = _mapper.Map<Mapa>(entityDTO);
            await _mapaRepository.UpdateAsync(MapaEntity);
            return entityDTO;
        }

        public async Task<MapaDTO> RemoveAsync(MapaDTO entityDTO)
        {
            var MapaEntity = _mapaRepository.GetByIdAsync(entityDTO.id).Result;
            await _mapaRepository.RemoveAsync(MapaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _mapaRepository?.Dispose();
        }

    }
}

