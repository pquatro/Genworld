using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class MateriaRepository : Repository<Materia>, IMateriaRepository
    {
        ApplicationDbContext _materiaContext;
        public MateriaRepository(ApplicationDbContext context) : base(context)
        {
            _materiaContext = context;
        }

        public async Task<IEnumerable<Materia>> GetAllAsync()
        {
            return await _materiaContext.Materias.ToListAsync();
        }

        public async Task<Materia> GetByIdAsync(int? id)
        {
            return await _materiaContext.Materias.FindAsync(id);
        }
    }
}
