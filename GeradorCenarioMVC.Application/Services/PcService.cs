using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class PcService : IPcService
    {
        private IPcRepository _pcRepository;
        private readonly IMapper _mapper;
        public PcService(IPcRepository context, IMapper mapper)
        {
            _pcRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<PcDTO>> GetAllAsync()
        {
            var PcsEntity = await _pcRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PcDTO>>(PcsEntity);
        }

        public async Task<PcDTO> GetByIdAsync(int? id)
        {
            var PcEntity = await _pcRepository.GetByIdAsync(id);
            return _mapper.Map<PcDTO>(PcEntity);
        }

        public async Task<PcDTO> CreateAsync(PcDTO entityDTO)
        {
            var PcEntity = _mapper.Map<Pc>(entityDTO);
            await _pcRepository.CreateAsync(PcEntity);
            return entityDTO;
        }

        public async Task<PcDTO> UpdateAsync(PcDTO entityDTO)
        {
            var PcEntity = _mapper.Map<Pc>(entityDTO);
            await _pcRepository.UpdateAsync(PcEntity);
            return entityDTO;
        }

        public async Task<PcDTO> RemoveAsync(PcDTO entityDTO)
        {
            var PcEntity = _pcRepository.GetByIdAsync(entityDTO.id).Result;
            await _pcRepository.RemoveAsync(PcEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _pcRepository?.Dispose();
        }

    }
}



