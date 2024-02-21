using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using GeradorCenarioMVC.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
    public class HomeController : Controller
    {
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> log, IWebHostEnvironment webHostEnvironment)
        {
            _logger = log;
			_userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }
        [HttpGet]
        public IActionResult Index()
        {
            _logger.LogInformation($"Testando o NLog em {DateTime.UtcNow}");
            _logger.LogWarning("NLog - Alerta");
            return View();
        }

		[HttpGet]
		public IActionResult About()
		{			
			return View();
		}


		public FileContentResult Photo()
		{
			
			Task<ApplicationUser> user = _userManager.FindByIdAsync(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

			return new FileContentResult(user.Result.Picture, "image/jpeg");
		}


        public FileContentResult UserPhotos()
        {

            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;
            string path = "";

            if (User.Identity.IsAuthenticated)
            {
                String userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                

				if (userId != null) {
					Task<ApplicationUser> userImage = _userManager.FindByIdAsync(userId);
                    if (userImage.Result.Picture != null) {
						return new FileContentResult(userImage.Result.Picture, "image/jpeg");
					}
				}
				
            }
           
            //string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");
            string fileName = Path.Combine(webRootPath, "Images", "avatar.jpg");

            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(fileName);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return File(imageData, "image/png");

           
        }


    }
}
