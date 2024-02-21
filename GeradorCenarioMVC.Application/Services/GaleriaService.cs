using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class GaleriaService : IGaleriaService
    {
        private IGaleriaRepository _galeriaRepository;
        private readonly IMapper _mapper;
        public GaleriaService(IGaleriaRepository context, IMapper mapper)
        {
            _galeriaRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<GaleriaDTO>> GetAllAsync()
        {
            var GaleriasEntity = await _galeriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GaleriaDTO>>(GaleriasEntity);
        }

        public async Task<GaleriaDTO> GetByIdAsync(int? id)
        {
            var GaleriaEntity = await _galeriaRepository.GetByIdAsync(id);
            return _mapper.Map<GaleriaDTO>(GaleriaEntity);
        }

        public async Task<GaleriaDTO> CreateAsync(GaleriaDTO entityDTO)
        {
            var GaleriaEntity = _mapper.Map<Galeria>(entityDTO);
            await _galeriaRepository.CreateAsync(GaleriaEntity);
            return entityDTO;
        }

        public async Task<GaleriaDTO> UpdateAsync(GaleriaDTO entityDTO)
        {
            var GaleriaEntity = _mapper.Map<Galeria>(entityDTO);
            await _galeriaRepository.UpdateAsync(GaleriaEntity);
            return entityDTO;
        }

        public async Task<GaleriaDTO> RemoveAsync(GaleriaDTO entityDTO)
        {
            var GaleriaEntity = _galeriaRepository.GetByIdAsync(entityDTO.id).Result;
            await _galeriaRepository.RemoveAsync(GaleriaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _galeriaRepository?.Dispose();
        }

    }
}
