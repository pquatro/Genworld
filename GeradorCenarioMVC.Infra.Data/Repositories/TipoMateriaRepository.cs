using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class TipoMateriaRepository : Repository<TipoMateria>, ITipoMateriaRepository
    {
        ApplicationDbContext _tipoMateriaContext;
        public TipoMateriaRepository(ApplicationDbContext context) : base(context)
        {
            _tipoMateriaContext = context;
        }

        public async Task<IEnumerable<TipoMateria>> GetAllAsync()
        {
            return await _tipoMateriaContext.TiposMateria.ToListAsync();
        }

        public async Task<TipoMateria> GetByIdAsync(int? id)
        {
            return await _tipoMateriaContext.TiposMateria.FindAsync(id);
        }
    }
}
