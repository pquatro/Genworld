using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class NpcRepository : Repository<Npc>, INpcRepository
    {
        ApplicationDbContext _NpcContext;
        public NpcRepository(ApplicationDbContext context) : base(context)
        {
            _NpcContext = context;
        }

        public async Task<IEnumerable<Npc>> GetAllAsync()
        {
            return await _NpcContext.Npcs.ToListAsync();
        }

        public async Task<Npc> GetByIdAsync(int? id)
        {
            return await _NpcContext.Npcs.FindAsync(id);
        }
    }
}
