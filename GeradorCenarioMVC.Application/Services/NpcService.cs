using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class NpcService : INpcService
    {
        private INpcRepository _npcRepository;
        private readonly IMapper _mapper;
        public NpcService(INpcRepository context, IMapper mapper)
        {
            _npcRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<NpcDTO>> GetAllAsync()
        {
            var NpcsEntity = await _npcRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<NpcDTO>>(NpcsEntity);
        }

        public async Task<NpcDTO> GetByIdAsync(int? id)
        {
            var NpcEntity = await _npcRepository.GetByIdAsync(id);
            return _mapper.Map<NpcDTO>(NpcEntity);
        }

        public async Task<NpcDTO> CreateAsync(NpcDTO entityDTO)
        {
            var NpcEntity = _mapper.Map<Npc>(entityDTO);
            await _npcRepository.CreateAsync(NpcEntity);
            return entityDTO;
        }

        public async Task<NpcDTO> UpdateAsync(NpcDTO entityDTO)
        {
            var NpcEntity = _mapper.Map<Npc>(entityDTO);
            await _npcRepository.UpdateAsync(NpcEntity);
            return entityDTO;
        }

        public async Task<NpcDTO> RemoveAsync(NpcDTO entityDTO)
        {
            var NpcEntity = _npcRepository.GetByIdAsync(entityDTO.id).Result;
            await _npcRepository.RemoveAsync(NpcEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _npcRepository?.Dispose();
        }

    }
}



