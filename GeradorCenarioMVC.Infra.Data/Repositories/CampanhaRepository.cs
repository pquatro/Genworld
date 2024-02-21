using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class CampanhaRepository : Repository<Campanha>, ICampanhaRepository
    {
        ApplicationDbContext _campanhaContext;
        public CampanhaRepository(ApplicationDbContext context) : base(context)
        {
            _campanhaContext = context;
        }

        public async Task<IEnumerable<Campanha>> GetAllAsync()
        {
            return await _campanhaContext.Campanhas.ToListAsync();
        }

        public async Task<Campanha> GetByIdAsync(int? id)
        {
            return await _campanhaContext.Campanhas.FindAsync(id);
        }
    }
}
