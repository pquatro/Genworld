using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{

    public class GeneroRepository : Repository<Genero>, IGeneroRepository
    {
        ApplicationDbContext _generoContext;
        public GeneroRepository(ApplicationDbContext context) : base(context)
        {
            _generoContext = context;
        }

        public async Task<IEnumerable<Genero>> GetAllAsync()
        {
            return await _generoContext.Generos.AsNoTracking().ToListAsync();
        }

        public async Task<Genero> GetByIdAsync(int? id)
        {
            return await _generoContext.Generos.FindAsync(id);
        }
    }
}