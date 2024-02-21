using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class SessaoRepository : Repository<Sessao>, ISessaoRepository
    {
        ApplicationDbContext _sessaoContext;
        public SessaoRepository(ApplicationDbContext context) : base(context)
        {
            _sessaoContext = context;
        }

        public async Task<IEnumerable<Sessao>> GetAllAsync()
        {
            return await _sessaoContext.Sessoes.ToListAsync();
        }

        public async Task<Sessao> GetByIdAsync(int? id)
        {
            return await _sessaoContext.Sessoes.FindAsync(id);
        }
    }
}
