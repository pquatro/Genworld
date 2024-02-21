using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class CategoriaMateriaService : ICategoriaMateriaService
    {
        private ICategoriaMateriaRepository _categoriaMateriaRepository;
        private readonly IMapper _mapper;
        public CategoriaMateriaService(ICategoriaMateriaRepository context, IMapper mapper)
        {
            _categoriaMateriaRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<CategoriaMateriaDTO>> GetAllAsync()
        {
            var CategoriaMateriasEntity = await _categoriaMateriaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaMateriaDTO>>(CategoriaMateriasEntity);
        }

        public async Task<CategoriaMateriaDTO> GetByIdAsync(int? id)
        {
            var CategoriaMateriaEntity = await _categoriaMateriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaMateriaDTO>(CategoriaMateriaEntity);
        }

        public async Task<CategoriaMateriaDTO> CreateAsync(CategoriaMateriaDTO entityDTO)
        {
            var CategoriaMateriaEntity = _mapper.Map<CategoriaMateria>(entityDTO);
            await _categoriaMateriaRepository.CreateAsync(CategoriaMateriaEntity);
            return entityDTO;
        }

        public async Task<CategoriaMateriaDTO> UpdateAsync(CategoriaMateriaDTO entityDTO)
        {
            var CategoriaMateriaEntity = _mapper.Map<CategoriaMateria>(entityDTO);
            await _categoriaMateriaRepository.UpdateAsync(CategoriaMateriaEntity);
            return entityDTO;
        }

        public async Task<CategoriaMateriaDTO> RemoveAsync(CategoriaMateriaDTO entityDTO)
        {
            var CategoriaMateriaEntity = _categoriaMateriaRepository.GetByIdAsync(entityDTO.id).Result;
            await _categoriaMateriaRepository.RemoveAsync(CategoriaMateriaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _categoriaMateriaRepository?.Dispose();
        }

    }
}
