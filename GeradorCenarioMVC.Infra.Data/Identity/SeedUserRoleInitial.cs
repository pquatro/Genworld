using GeradorCenarioMVC.Domain.Account;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GeradorCenarioMVC.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private IUsuarioRepository _usuarioRepository;

        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager,
              UserManager<ApplicationUser> userManager,
              IUsuarioRepository usuarioRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _usuarioRepository = usuarioRepository;
        }

        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.FirstName = "Usuário";
                user.LastName = "Localhost";
                user.RecebeEmail = false;
                user.Perfil = (Perfil)1;
                              


                IdentityResult result = _userManager.CreateAsync(user, "Pedro193325-8").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();

                    //salvando em usuario tambem
                    Task<ApplicationUser> userSaved = _userManager.FindByNameAsync(user.UserName);
                    Usuario usuario = new Usuario( 
                        userId: userSaved.Result.Id, 
                        nomePrimeiro: userSaved.Result.FirstName,
                        nomeUltimo: userSaved.Result.LastName,                                                
                        email: userSaved.Result.Email,
                        emailVerificado: userSaved.Result.EmailConfirmed,
                        recebeEmail: false,
                        ultimoAcesso:DateTime.Now,
                        ativo:true,
                        perfil: (Perfil)1,
                        picture: null                       

                        ) { };
                     _usuarioRepository.CreateAsync(usuario).Wait(); 

                }
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.FirstName = "Administrador";
                user.LastName = "Localhost";
                user.RecebeEmail = false;
                user.Perfil = (Perfil)0;

                IdentityResult result = _userManager.CreateAsync(user, "Pedro193325-8").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait();

                    //salvando em usuario tambem
                    Task<ApplicationUser> userSaved = _userManager.FindByNameAsync(user.UserName);
                    Usuario usuario = new Usuario(
                        userId: userSaved.Result.Id,
                        nomePrimeiro: userSaved.Result.FirstName,
                        nomeUltimo: userSaved.Result.LastName,
                        email: userSaved.Result.Email,
                        emailVerificado: userSaved.Result.EmailConfirmed,
                        recebeEmail: false,
                        ultimoAcesso: DateTime.Now,
                        ativo: true,
                        perfil: (Perfil)0,
                        picture: null                      
                        )
                    { };
                    _usuarioRepository.CreateAsync(usuario).Wait();
                }
            }

        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
