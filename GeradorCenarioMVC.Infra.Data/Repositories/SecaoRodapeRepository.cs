using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class SecaoRodapeRepository : Repository<SecaoRodape>, ISecaoRodapeRepository
    {
        ApplicationDbContext _secaoRodapeContext;
        public SecaoRodapeRepository(ApplicationDbContext context) : base(context)
        {
            _secaoRodapeContext = context;
        }

        public async Task<IEnumerable<SecaoRodape>> GetAllAsync()
        {
            return await _secaoRodapeContext.SecoesRodape.ToListAsync();
        }

        public async Task<SecaoRodape> GetByIdAsync(int? id)
        {
            return await _secaoRodapeContext.SecoesRodape.FindAsync(id);
        }
    }
}
