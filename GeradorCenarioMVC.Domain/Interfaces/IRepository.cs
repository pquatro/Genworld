using GeradorCenarioMVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Domain.Interfaces
{
    //todo - verificar o IDisposable
    public interface IRepository<T> : IDisposable where T : Entity
    {        
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int? id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> RemoveAsync(T entity);

        
        //Task<T> FindByConditionAsync(Expression<Func<T, bool>> predicate);        
    }
}
