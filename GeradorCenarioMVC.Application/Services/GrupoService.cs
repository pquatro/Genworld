using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class GrupoService : IGrupoService
    {
        private IGrupoRepository _grupoRepository;
        private readonly IMapper _mapper;
        public GrupoService(IGrupoRepository context, IMapper mapper)
        {
            _grupoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<GrupoDTO>> GetAllAsync()
        {
            var GruposEntity = await _grupoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GrupoDTO>>(GruposEntity);
        }

        public async Task<GrupoDTO> GetByIdAsync(int? id)
        {
            var GrupoEntity = await _grupoRepository.GetByIdAsync(id);
            return _mapper.Map<GrupoDTO>(GrupoEntity);
        }

        public async Task<GrupoDTO> CreateAsync(GrupoDTO entityDTO)
        {
            var GrupoEntity = _mapper.Map<Grupo>(entityDTO);
            await _grupoRepository.CreateAsync(GrupoEntity);
            return entityDTO;
        }

        public async Task<GrupoDTO> UpdateAsync(GrupoDTO entityDTO)
        {
            var GrupoEntity = _mapper.Map<Grupo>(entityDTO);
            await _grupoRepository.UpdateAsync(GrupoEntity);
            return entityDTO;
        }

        public async Task<GrupoDTO> RemoveAsync(GrupoDTO entityDTO)
        {
            var GrupoEntity = _grupoRepository.GetByIdAsync(entityDTO.id).Result;
            await _grupoRepository.RemoveAsync(GrupoEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _grupoRepository?.Dispose();
        }

    }
}