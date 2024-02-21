using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class TipoNpcRepository : Repository<TipoNpc>, ITipoNpcRepository
    {
        ApplicationDbContext _tipoNpcContext;
        public TipoNpcRepository(ApplicationDbContext context) : base(context)
        {
            _tipoNpcContext = context;
        }

        public async Task<IEnumerable<TipoNpc>> GetAllAsync()
        {
            return await _tipoNpcContext.TiposNpc.ToListAsync();
        }

        public async Task<TipoNpc> GetByIdAsync(int? id)
        {
            return await _tipoNpcContext.TiposNpc.FindAsync(id);
        }
    }
}
