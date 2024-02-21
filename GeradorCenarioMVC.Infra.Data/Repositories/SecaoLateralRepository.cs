using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class SecaoLateralRepository : Repository<SecaoLateral>, ISecaoLateralRepository
    {
        ApplicationDbContext _secaoLateralContext;
        public SecaoLateralRepository(ApplicationDbContext context) : base(context)
        {
            _secaoLateralContext = context;
        }

        public async Task<IEnumerable<SecaoLateral>> GetAllAsync()
        {
            return await _secaoLateralContext.SecoesLateral.ToListAsync();
        }

        public async Task<SecaoLateral> GetByIdAsync(int? id)
        {
            return await _secaoLateralContext.SecoesLateral.FindAsync(id);
        }
    }
}
