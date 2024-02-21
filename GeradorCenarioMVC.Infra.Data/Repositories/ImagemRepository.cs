using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class ImagemRepository : Repository<Imagem>, IImagemRepository
    {
        ApplicationDbContext _imagemContext;
        public ImagemRepository(ApplicationDbContext context) : base(context)
        {
            _imagemContext = context;
        }

        public async Task<IEnumerable<Imagem>> GetAllAsync()
        {
            return await _imagemContext.Imagens.ToListAsync();
        }

        public async Task<Imagem> GetByIdAsync(int? id)
        {
            return await _imagemContext.Imagens.FindAsync(id);
        }
    }
}
