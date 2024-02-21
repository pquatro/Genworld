using GeradorCenarioMVC.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace GeradorCenarioMVC.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }

        public bool? RecebeEmail { get; set; }
        public DateTime? UltimoAcesso { get; set; }
        public byte[]? Picture { get; set; }
        public Perfil Perfil { get; set; } = Perfil.Usuario;

		
	}
}
