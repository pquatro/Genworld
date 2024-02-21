using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class MateriaService : IMateriaService
    {
        private IMateriaRepository _materiaRepository;
        private readonly IMapper _mapper;
        public MateriaService(IMateriaRepository context, IMapper mapper)
        {
            _materiaRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MateriaDTO>> GetAllAsync()
        {
            var MateriasEntity = await _materiaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MateriaDTO>>(MateriasEntity);
        }

        public async Task<MateriaDTO> GetByIdAsync(int? id)
        {
            var MateriaEntity = await _materiaRepository.GetByIdAsync(id);
            return _mapper.Map<MateriaDTO>(MateriaEntity);
        }

        public async Task<MateriaDTO> CreateAsync(MateriaDTO entityDTO)
        {
            var MateriaEntity = _mapper.Map<Materia>(entityDTO);
            await _materiaRepository.CreateAsync(MateriaEntity);
            return entityDTO;
        }

        public async Task<MateriaDTO> UpdateAsync(MateriaDTO entityDTO)
        {
            var MateriaEntity = _mapper.Map<Materia>(entityDTO);
            await _materiaRepository.UpdateAsync(MateriaEntity);
            return entityDTO;
        }

        public async Task<MateriaDTO> RemoveAsync(MateriaDTO entityDTO)
        {
            var MateriaEntity = _materiaRepository.GetByIdAsync(entityDTO.id).Result;
            await _materiaRepository.RemoveAsync(MateriaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _materiaRepository?.Dispose();
        }

    }
}


