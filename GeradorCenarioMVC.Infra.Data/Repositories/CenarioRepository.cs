using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class CenarioRepository : Repository<Cenario>, ICenarioRepository
    {
        ApplicationDbContext _cenarioContext;
        public CenarioRepository(ApplicationDbContext context) : base(context)
        {
            _cenarioContext = context;
        }

        public async Task<IEnumerable<Cenario>> GetAllAsync()
        {
            return await _cenarioContext.Cenarios.AsNoTracking().ToListAsync();
        }

        public async Task<Cenario> GetByIdAsync(int? id)
        {
            return await _cenarioContext.Cenarios.FindAsync(id);
        }		

		public async Task<Cenario> GetCenarioCenarioGeneroAsync(int? id)
        {
            return await _cenarioContext.Cenarios.Include(c => c.CenarioGeneros).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Cenario> GetCenarioTagAsync(int? id)
        {
            return await _cenarioContext.Cenarios.Include(c => c.Tags).SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}
