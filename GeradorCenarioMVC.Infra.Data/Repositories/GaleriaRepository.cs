using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class GaleriaRepository : Repository<Galeria>, IGaleriaRepository
    {
        ApplicationDbContext _galeriaContext;
        public GaleriaRepository(ApplicationDbContext context) : base(context)
        {
            _galeriaContext = context;
        }

        public async Task<IEnumerable<Galeria>> GetAllAsync()
        {
            return await _galeriaContext.Galerias.ToListAsync();
        }

        public async Task<Galeria> GetByIdAsync(int? id)
        {
            return await _galeriaContext.Galerias.FindAsync(id);
        }
    }
}
