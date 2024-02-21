using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository context, IMapper mapper)
        {
            _tagRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<TagDTO>> GetAllAsync()
        {
            var TagsEntity = await _tagRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TagDTO>>(TagsEntity);
        }

        public async Task<TagDTO> GetByIdAsync(int? id)
        {
            var TagEntity = await _tagRepository.GetByIdAsync(id);
            return _mapper.Map<TagDTO>(TagEntity);
        }

        public async Task<TagDTO> CreateAsync(TagDTO entityDTO)
        {
            var TagEntity = _mapper.Map<Tag>(entityDTO);
            await _tagRepository.CreateAsync(TagEntity);
            return entityDTO;
        }

        public async Task<TagDTO> UpdateAsync(TagDTO entityDTO)
        {
            var TagEntity = _mapper.Map<Tag>(entityDTO);
            await _tagRepository.UpdateAsync(TagEntity);
            return entityDTO;
        }

        public async Task<TagDTO> RemoveAsync(TagDTO entityDTO)
        {
            var TagEntity = _tagRepository.GetByIdAsync(entityDTO.id).Result;
            await _tagRepository.RemoveAsync(TagEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _tagRepository?.Dispose();
        }

    }
}




