using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{

    public class CenarioGeneroRepository : Repository<CenarioGenero>, ICenarioGeneroRepository
    {
        ApplicationDbContext _cenarioGeneroContext;
        public CenarioGeneroRepository(ApplicationDbContext context) : base(context)
        {
            _cenarioGeneroContext = context;
        }

        public async Task<IEnumerable<CenarioGenero>> GetAllAsync()
        {
            return await _cenarioGeneroContext.CenarioGeneros.AsNoTracking().ToListAsync();
        }

        public async Task<CenarioGenero> GetByIdAsync(int? id)
        {
            return await _cenarioGeneroContext.CenarioGeneros.FindAsync(id);
        }
    }
}