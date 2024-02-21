using AutoMapper;
using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;

namespace GeradorCenarioMVC.Application.Services
{
    public class Service<T,U> : IService<T> where T : EntityDTO where U : Entity
    {

        private IRepository<U> _repository;
        private readonly IMapper _mapper;
        public Service(IRepository<U> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entity = await _repository.GetAllAsync();            
            return _mapper.Map<IEnumerable<T>>(entity);
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<T>(entity);
        }

        public async Task<T> CreateAsync(T entityDTO)
        {
            var entity = _mapper.Map<U>(entityDTO);
            await _repository.CreateAsync(entity);
            return entityDTO;
        }


        public async Task<T> UpdateAsync(T entityDTO)
        {
            var entity = _mapper.Map<U>(entityDTO);
            await _repository.UpdateAsync(entity);
            return entityDTO;
        }
        public async Task<T> RemoveAsync(T entityDTO)
        {
            var entity = _repository.GetByIdAsync(entityDTO.id).Result;
            await _repository.RemoveAsync(entity);
            return entityDTO;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
