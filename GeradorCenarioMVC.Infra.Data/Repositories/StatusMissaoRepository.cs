using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class StatusMissaoRepository : Repository<StatusMissao>, IStatusMissaoRepository
    {
        ApplicationDbContext _statusMissaoContext;
        public StatusMissaoRepository(ApplicationDbContext context) : base(context)
        {
            _statusMissaoContext = context;
        }

        public async Task<IEnumerable<StatusMissao>> GetAllAsync()
        {
            return await _statusMissaoContext.StatusMissoes.ToListAsync();
        }

        public async Task<StatusMissao> GetByIdAsync(int? id)
        {
            return await _statusMissaoContext.StatusMissoes.FindAsync(id);
        }
    }
}
