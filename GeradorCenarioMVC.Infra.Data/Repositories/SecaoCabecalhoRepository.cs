using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class SecaoCabecalhoRepository : Repository<SecaoCabecalho>, ISecaoCabecalhoRepository
    {
        ApplicationDbContext _secaoCabecalhoContext;
        public SecaoCabecalhoRepository(ApplicationDbContext context) : base(context)
        {
            _secaoCabecalhoContext = context;
        }

        public async Task<IEnumerable<SecaoCabecalho>> GetAllAsync()
        {
            return await _secaoCabecalhoContext.SecoesCabecalho.ToListAsync();
        }

        public async Task<SecaoCabecalho> GetByIdAsync(int? id)
        {
            return await _secaoCabecalhoContext.SecoesCabecalho.FindAsync(id);
        }
    }
}
