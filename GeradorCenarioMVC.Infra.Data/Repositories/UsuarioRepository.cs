using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeradorCenarioMVC.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        ApplicationDbContext _usuarioContext;
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
            _usuarioContext = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _usuarioContext.Usuarios.AsNoTracking().ToListAsync();
        }
        
        public async Task<Usuario> GetByIdAsync(int? id)
        {
            return await _usuarioContext.Usuarios.FindAsync(id);
        }
       
    }
}
