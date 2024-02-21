using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class ConquistaService : IConquistaService
    {
        private IConquistaRepository _conquistaRepository;
        private readonly IMapper _mapper;
        public ConquistaService(IConquistaRepository context, IMapper mapper)
        {
            _conquistaRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ConquistaDTO>> GetAllAsync()
        {
            var ConquistasEntity = await _conquistaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConquistaDTO>>(ConquistasEntity);
        }

        public async Task<ConquistaDTO> GetByIdAsync(int? id)
        {
            var ConquistaEntity = await _conquistaRepository.GetByIdAsync(id);
            return _mapper.Map<ConquistaDTO>(ConquistaEntity);
        }

        public async Task<ConquistaDTO> CreateAsync(ConquistaDTO entityDTO)
        {
            var ConquistaEntity = _mapper.Map<Conquista>(entityDTO);
            await _conquistaRepository.CreateAsync(ConquistaEntity);
            return entityDTO;
        }

        public async Task<ConquistaDTO> UpdateAsync(ConquistaDTO entityDTO)
        {
            var ConquistaEntity = _mapper.Map<Conquista>(entityDTO);
            await _conquistaRepository.UpdateAsync(ConquistaEntity);
            return entityDTO;
        }

        public async Task<ConquistaDTO> RemoveAsync(ConquistaDTO entityDTO)
        {
            var ConquistaEntity = _conquistaRepository.GetByIdAsync(entityDTO.id).Result;
            await _conquistaRepository.RemoveAsync(ConquistaEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _conquistaRepository?.Dispose();
        }

    }
}