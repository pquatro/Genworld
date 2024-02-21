using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class EnredoRepository : Repository<Enredo>, IEnredoRepository
    {
        ApplicationDbContext _enredoContext;
        public EnredoRepository(ApplicationDbContext context) : base(context)
        {
            _enredoContext = context;
        }

        public async Task<IEnumerable<Enredo>> GetAllAsync()
        {
            return await _enredoContext.Enredos.ToListAsync();
        }

        public async Task<Enredo> GetByIdAsync(int? id)
        {
            return await _enredoContext.Enredos.FindAsync(id);
        }
    }
}
