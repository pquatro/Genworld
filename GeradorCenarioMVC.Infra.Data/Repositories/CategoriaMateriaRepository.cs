using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class CategoriaMateriaRepository : Repository<CategoriaMateria>, ICategoriaMateriaRepository
    {
        ApplicationDbContext _categoriaMateriaContext;
        public CategoriaMateriaRepository(ApplicationDbContext context) : base(context)
        {
            _categoriaMateriaContext = context;
        }

        public async Task<IEnumerable<CategoriaMateria>> GetAllAsync()
        {
            return await _categoriaMateriaContext.CategoriasMateria.ToListAsync();
        }

        public async Task<CategoriaMateria> GetByIdAsync(int? id)
        {
            return await _categoriaMateriaContext.CategoriasMateria.FindAsync(id);
        }
    }
}
