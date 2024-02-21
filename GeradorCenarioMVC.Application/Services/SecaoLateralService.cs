using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class SecaoLateralService : ISecaoLateralService
    {
        private ISecaoLateralRepository _secaoLateralRepository;
        private readonly IMapper _mapper;
        public SecaoLateralService(ISecaoLateralRepository context, IMapper mapper)
        {
            _secaoLateralRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SecaoLateralDTO>> GetAllAsync()
        {
            var SecaoLateralsEntity = await _secaoLateralRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SecaoLateralDTO>>(SecaoLateralsEntity);
        }

        public async Task<SecaoLateralDTO> GetByIdAsync(int? id)
        {
            var SecaoLateralEntity = await _secaoLateralRepository.GetByIdAsync(id);
            return _mapper.Map<SecaoLateralDTO>(SecaoLateralEntity);
        }

        public async Task<SecaoLateralDTO> CreateAsync(SecaoLateralDTO entityDTO)
        {
            var SecaoLateralEntity = _mapper.Map<SecaoLateral>(entityDTO);
            await _secaoLateralRepository.CreateAsync(SecaoLateralEntity);
            return entityDTO;
        }

        public async Task<SecaoLateralDTO> UpdateAsync(SecaoLateralDTO entityDTO)
        {
            var SecaoLateralEntity = _mapper.Map<SecaoLateral>(entityDTO);
            await _secaoLateralRepository.UpdateAsync(SecaoLateralEntity);
            return entityDTO;
        }

        public async Task<SecaoLateralDTO> RemoveAsync(SecaoLateralDTO entityDTO)
        {
            var SecaoLateralEntity = _secaoLateralRepository.GetByIdAsync(entityDTO.id).Result;
            await _secaoLateralRepository.RemoveAsync(SecaoLateralEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _secaoLateralRepository?.Dispose();
        }

    }
}



