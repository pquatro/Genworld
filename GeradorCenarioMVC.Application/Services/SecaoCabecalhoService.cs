using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class SecaoCabecalhoService : ISecaoCabecalhoService
    {
        private ISecaoCabecalhoRepository _secaoCabecalhoRepository;
        private readonly IMapper _mapper;
        public SecaoCabecalhoService(ISecaoCabecalhoRepository context, IMapper mapper)
        {
            _secaoCabecalhoRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<SecaoCabecalhoDTO>> GetAllAsync()
        {
            var SecaoCabecalhosEntity = await _secaoCabecalhoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SecaoCabecalhoDTO>>(SecaoCabecalhosEntity);
        }

        public async Task<SecaoCabecalhoDTO> GetByIdAsync(int? id)
        {
            var SecaoCabecalhoEntity = await _secaoCabecalhoRepository.GetByIdAsync(id);
            return _mapper.Map<SecaoCabecalhoDTO>(SecaoCabecalhoEntity);
        }

        public async Task<SecaoCabecalhoDTO> CreateAsync(SecaoCabecalhoDTO entityDTO)
        {
            var SecaoCabecalhoEntity = _mapper.Map<SecaoCabecalho>(entityDTO);
            await _secaoCabecalhoRepository.CreateAsync(SecaoCabecalhoEntity);
            return entityDTO;
        }

        public async Task<SecaoCabecalhoDTO> UpdateAsync(SecaoCabecalhoDTO entityDTO)
        {
            var SecaoCabecalhoEntity = _mapper.Map<SecaoCabecalho>(entityDTO);
            await _secaoCabecalhoRepository.UpdateAsync(SecaoCabecalhoEntity);
            return entityDTO;
        }

        public async Task<SecaoCabecalhoDTO> RemoveAsync(SecaoCabecalhoDTO entityDTO)
        {
            var SecaoCabecalhoEntity = _secaoCabecalhoRepository.GetByIdAsync(entityDTO.id).Result;
            await _secaoCabecalhoRepository.RemoveAsync(SecaoCabecalhoEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _secaoCabecalhoRepository?.Dispose();
        }

    }
}




