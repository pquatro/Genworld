using GeradorCenarioMVC.Domain.Account;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Identity.Validation;
using Microsoft.AspNetCore.Identity;

namespace GeradorCenarioMVC.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUsuarioRepository _usuarioRepository;
        private IPasswordHasher<ApplicationUser> _passwordHasher;
        public AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IUsuarioRepository usuarioRepository, IPasswordHasher<ApplicationUser> passwordHash)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _usuarioRepository = usuarioRepository;
            _passwordHasher = passwordHash;
        }
        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                //atualizando UltimoAcesso em usuario
                Task<ApplicationUser> userSaved = _userManager.FindByEmailAsync(email);

                var listaUsuario = await _usuarioRepository.GetAllAsync();
                var usuarioFinded = listaUsuario.FirstOrDefault(x => x.UserId == userSaved.Result.Id);
                usuarioFinded.UltimoAcesso = DateTime.Now;

                _usuarioRepository.UpdateAsync(usuarioFinded);
            }

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RegisterUser(string email, string password, string firstname, string lastname)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstname,
                LastName = lastname
            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                //salvando em usuario tambem
                Task<ApplicationUser> userSaved = _userManager.FindByNameAsync(applicationUser.UserName);
                Usuario usuario = new Usuario(
                    userId: userSaved.Result.Id,
                    nomePrimeiro: userSaved.Result.FirstName,
                    nomeUltimo: userSaved.Result.LastName,
                    email: userSaved.Result.Email,
                    emailVerificado: userSaved.Result.EmailConfirmed,
                    recebeEmail: false,
                    ultimoAcesso: DateTime.Now,
                    ativo: true,
                    perfil: (Perfil)1,
                    picture: null

                    )
                { };
                _usuarioRepository.CreateAsync(usuario);

                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
            }
            else
            {
				string msg = null;
				foreach (var item in result.Errors)
				{
					msg = msg + item.Description + Environment.NewLine;
				}
				IdentityExceptionValidation.When(true, null, msg, null);
			}
            return result.Succeeded;
        }

        public async Task<bool> RegisterUserFull(string email, string password, string firstname, string lastname, bool? recebeEmail, byte[]? picture)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                FirstName = firstname,
                LastName = lastname,
                RecebeEmail = recebeEmail,
                Picture = picture,

            };
            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);				
			}
            else
            {
                string msg = null;
                foreach (var item in result.Errors)
                {
					msg = msg + item.Description + Environment.NewLine;					
				}
				IdentityExceptionValidation.When(true, null, msg, null);
			}

			return result.Succeeded;

		}

        public async Task<bool> DeleteUser(string id)
        {

            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {



                IdentityResult identityResult = await _userManager.DeleteAsync(user);
                if (!identityResult.Succeeded)
                {
                    IdentityExceptionValidation.When(true, null, "Não foi possivel excluir o usuário identity.",null);
                }

                return identityResult.Succeeded;
            }
            else
            {
                IdentityExceptionValidation.When(true, "notFound", null, null);
            }

            return false;
        }

        public async Task<bool> UpdateUser(string email, string password, string firstname, string lastname, bool? recebeEmail, byte[]? picture)
        {            

            ApplicationUser user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    IdentityExceptionValidation.When(true, "emptyField", "Não foi possivel excluir o usuário identity.","Email");                

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                else
                    IdentityExceptionValidation.When(true, "emptyField", "Não foi possivel excluir o usuário identity.", "Password");
                

                if (!string.IsNullOrEmpty(firstname))
                    user.FirstName = firstname;
                else
                    IdentityExceptionValidation.When(true, "emptyField", "Não foi possivel excluir o usuário identity.", "Primeiro nome");

                if (!string.IsNullOrEmpty(lastname))
                    user.LastName = lastname;
                else
                    IdentityExceptionValidation.When(true, "emptyField", "Não foi possivel excluir o usuário identity.", "Último nome");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return result.Succeeded;
                    else
                        IdentityExceptionValidation.When(true, null, "Não foi possivel atualizar o usuário identity.", null);
                }
            }
            else
                IdentityExceptionValidation.When(true, "notFound", null, null);
                       

            return false;
        }
    }
}
