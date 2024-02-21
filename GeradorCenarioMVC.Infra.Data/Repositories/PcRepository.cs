using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class PcRepository : Repository<Pc>, IPcRepository
    {
        ApplicationDbContext _pcContext;
        
        public PcRepository(ApplicationDbContext context) : base(context)
        {
            _pcContext = context;            
        }

        public async Task<IEnumerable<Pc>> GetAllAsync()
        {
            return await _pcContext.Pcs.ToListAsync();
        }

        public async Task<Pc> GetByIdAsync(int? id)
        {
            return await _pcContext.Pcs.FindAsync(id);
        }


    }
}
