using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class TipoConquistaRepository : Repository<TipoConquista>, ITipoConquistaRepository
    {
        ApplicationDbContext _tipoConquistaContext;
        public TipoConquistaRepository(ApplicationDbContext context) : base(context)
        {
            _tipoConquistaContext = context;
        }

        public async Task<IEnumerable<TipoConquista>> GetAllAsync()
        {
            //o método AsNoTracking para consultas que são somente leitura. Elas não serão mantidas no contexto.
            return await _tipoConquistaContext.TiposConquista.AsNoTracking().ToListAsync();
                       

        }

        public async Task<TipoConquista> GetByIdAsync(int? id)
        {
            return await _tipoConquistaContext.TiposConquista.FindAsync(id);
        }
    }
}
