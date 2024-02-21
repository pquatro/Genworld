using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class ConquistaRepository : Repository<Conquista>, IConquistaRepository
    {
        ApplicationDbContext _conquistaContext;
        public ConquistaRepository(ApplicationDbContext context) : base(context)
        {
            _conquistaContext = context;
        }

        public async Task<IEnumerable<Conquista>> GetAllAsync()
        {
            return await _conquistaContext.Conquistas.AsNoTracking().Include(c => c.TipoConquista).ToListAsync();
        }

        public async Task<Conquista> GetByIdAsync(int? id)
        {
            return await _conquistaContext.Conquistas.Include(c=>c.TipoConquista).SingleOrDefaultAsync(p=>p.Id==id);
        }		
	}
}
