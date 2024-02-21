using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{

    public class ImagemService : IImagemService
    {
        private IImagemRepository _imagemRepository;
        private readonly IMapper _mapper;
        public ImagemService(IImagemRepository context, IMapper mapper)
        {
            _imagemRepository = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<ImagemDTO>> GetAllAsync()
        {
            var ImagemsEntity = await _imagemRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ImagemDTO>>(ImagemsEntity);
        }

        public async Task<ImagemDTO> GetByIdAsync(int? id)
        {
            var ImagemEntity = await _imagemRepository.GetByIdAsync(id);
            return _mapper.Map<ImagemDTO>(ImagemEntity);
        }

        public async Task<ImagemDTO> CreateAsync(ImagemDTO entityDTO)
        {
            var ImagemEntity = _mapper.Map<Imagem>(entityDTO);
            await _imagemRepository.CreateAsync(ImagemEntity);
            return entityDTO;
        }

        public async Task<ImagemDTO> UpdateAsync(ImagemDTO entityDTO)
        {
            var ImagemEntity = _mapper.Map<Imagem>(entityDTO);
            await _imagemRepository.UpdateAsync(ImagemEntity);
            return entityDTO;
        }

        public async Task<ImagemDTO> RemoveAsync(ImagemDTO entityDTO)
        {
            var ImagemEntity = _imagemRepository.GetByIdAsync(entityDTO.id).Result;
            await _imagemRepository.RemoveAsync(ImagemEntity);
            return entityDTO;
        }

        public void Dispose()
        {
            _imagemRepository?.Dispose();
        }

    }
}