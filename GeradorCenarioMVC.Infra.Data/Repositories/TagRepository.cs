using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        ApplicationDbContext _tagContext;
        public TagRepository(ApplicationDbContext context) : base(context)
        {
            _tagContext = context;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _tagContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int? id)
        {
            return await _tagContext.Tags.FindAsync(id);
        }
    }
}
