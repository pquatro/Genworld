using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class TipoMissaoRepository : Repository<TipoMissao>, ITipoMissaoRepository
    {
        ApplicationDbContext _tipoMissaoContext;
        public TipoMissaoRepository(ApplicationDbContext context) : base(context)
        {
            _tipoMissaoContext = context;
        }

        public async Task<IEnumerable<TipoMissao>> GetAllAsync()
        {
            return await _tipoMissaoContext.TiposMissao.ToListAsync();
        }

        public async Task<TipoMissao> GetByIdAsync(int? id)
        {
            return await _tipoMissaoContext.TiposMissao.FindAsync(id);
        }
    }
}
