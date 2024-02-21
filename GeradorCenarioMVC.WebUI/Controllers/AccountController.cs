using GeradorCenarioMVC.Domain.Account;
using GeradorCenarioMVC.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GeradorCenarioMVC.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authentication;
        public AccountController(IAuthenticate authentication)
        {
            _authentication = authentication;
        }


        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authentication.Authenticate(model.Email, model.Password);

            if (result)
            {
                if (string.IsNullOrEmpty(model.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.(password must be strong).");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authentication.RegisterUser(model.Email, model.Password,model.FistName,model.LastName);

            if (result)
            {
                return Redirect("/");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid register attempt (password must be strong.");
                return View(model);
            }
        }

		[HttpGet]
		public async Task<IActionResult> RegisterBox(string email, string password, string fistName, string lastName)
		{
            try
            {
				var result = await _authentication.RegisterUser(email, password, fistName, lastName);

				if (result)
				{
					return Redirect("/");
				}
				
			}
            catch (Exception ex)
            {
				return BadRequest(ex.Message);
			}

            return null;
			
		}

		public async Task<IActionResult> Logout()
        {
            await _authentication.Logout();
            return Redirect("/Account/Login");
        }

    }
}
