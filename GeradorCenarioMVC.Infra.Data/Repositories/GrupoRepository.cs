using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        ApplicationDbContext _grupoContext;
        public GrupoRepository(ApplicationDbContext context) : base(context)
        {
            _grupoContext = context;
        }

        public async Task<IEnumerable<Grupo>> GetAllAsync()
        {
            return await _grupoContext.Grupos.ToListAsync();
        }

        public async Task<Grupo> GetByIdAsync(int? id)
        {
            return await _grupoContext.Grupos.FindAsync(id);
        }
    }
}
