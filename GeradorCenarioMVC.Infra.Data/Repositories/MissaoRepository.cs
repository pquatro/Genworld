using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class MissaoRepository : Repository<Missao>, IMissaoRepository
    {
        ApplicationDbContext _MissaoContext;
        public MissaoRepository(ApplicationDbContext context) : base(context)
        {
            _MissaoContext = context;
        }

        public async Task<IEnumerable<Missao>> GetAllAsync()
        {
            return await _MissaoContext.Missoes.ToListAsync();
        }

        public async Task<Missao> GetByIdAsync(int? id)
        {
            return await _MissaoContext.Missoes.FindAsync(id);
        }
    }
}
