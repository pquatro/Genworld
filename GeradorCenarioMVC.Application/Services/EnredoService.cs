using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class EnredoService : IEnredoService
    {
        private IEnredoRepository _enredoRepository;
        private readonly IMapper _mapper;
        public EnredoService(IEnredoRepository context, IMapper mapper)
        {
            _enredoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<EnredoDTO>> GetAllAsync()
        {
            var EnredosEntity = await _enredoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EnredoDTO>>(EnredosEntity);
        }

        public async Task<EnredoDTO> GetByIdAsync(int? id)
        {
            var EnredoEntity = await _enredoRepository.GetByIdAsync(id);
            return _mapper.Map<EnredoDTO>(EnredoEntity);
        }

        public async Task<EnredoDTO> CreateAsync(EnredoDTO entityDTO)
        {
            var EnredoEntity = _mapper.Map<Enredo>(entityDTO);
            await _enredoRepository.CreateAsync(EnredoEntity);
            return entityDTO;
        }

        public async Task<EnredoDTO> UpdateAsync(EnredoDTO entityDTO)
        {
            var EnredoEntity = _mapper.Map<Enredo>(entityDTO);
            await _enredoRepository.UpdateAsync(EnredoEntity);
            return entityDTO;
        }

        public async Task<EnredoDTO> RemoveAsync(EnredoDTO entityDTO)
        {
            var EnredoEntity = _enredoRepository.GetByIdAsync(entityDTO.id).Result;
            await _enredoRepository.RemoveAsync(EnredoEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _enredoRepository?.Dispose();
        }

    }
}