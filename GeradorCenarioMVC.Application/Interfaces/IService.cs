using GeradorCenarioMVC.Application.DTOs;

namespace GeradorCenarioMVC.Application.Interfaces
{
    //todo - verificar o IDisposable
    public interface IService<T> : IDisposable where T : EntityDTO
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> CreateAsync(T entityDTO);
        Task<T> UpdateAsync(T entityDTO);
        Task<T> RemoveAsync(T entityDTO);
    }
}
