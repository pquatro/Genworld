using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class MapaRepository : Repository<Mapa>, IMapaRepository
    {
        ApplicationDbContext _mapaContext;
        public MapaRepository(ApplicationDbContext context) : base(context)
        {
            _mapaContext = context;
        }

        public async Task<IEnumerable<Mapa>> GetAllAsync()
        {
            return await _mapaContext.Mapas.ToListAsync();
        }

        public async Task<Mapa> GetByIdAsync(int? id)
        {
            return await _mapaContext.Mapas.FindAsync(id);
        }
    }
}
