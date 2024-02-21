using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Application.Services;
using GeradorCenarioMVC.Domain.Account;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.Infra.Data.Identity;
using GeradorCenarioMVC.Infra.Data.Migrations;
using GeradorCenarioMVC.WebUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
		private readonly IAuthenticate _authentication;
		private readonly ILogger<HomeController> _logger;
		private readonly UserManager<ApplicationUser> _userManager;                
        

        public UsuarioController(IUsuarioService usuarioService, IAuthenticate authentication, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _usuarioService = usuarioService;
			_authentication = authentication;
			_userManager = userManager;            
            _logger = logger;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        #region dataTable
        //Post api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post()
        {

            try
            {
                var requestFormData = Request.Form;
                var enumerableUsuario = await _usuarioService.GetAllAsync();

                //paginação e ordenação
                IEnumerable<UsuarioDTO> listaForm = ProcessarDadosForm(enumerableUsuario, requestFormData);


                //busca
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    listaForm = listaForm.Where(m =>
                                                m.id.ToString().Contains(searchValue)
                                             || m.nomePrimeiro.Contains(searchValue)
                                             || m.nomeUltimo.Contains(searchValue)
                                             || m.email.Contains(searchValue)
                                             || (m.emailVerificado == true ? "sim" : "não").Contains(searchValue)
                                             || (m.recebeEmail == true ? "sim" : "não").Contains(searchValue)
                                             || m.ultimoAcesso.ToString().Contains(searchValue)
                                             || (m.ativo == true ? "sim" : "não").Contains(searchValue)
                    ).ToList<UsuarioDTO>();
                }


                var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<UsuarioDTO>(), recordsTotal = listaForm.Count<UsuarioDTO>(), data = listaForm };
                return Ok(jsonData);


            }
            catch (Exception ex)
            {
                var jsonData = new { Result = "ERROR", Message = ex.Message };
                _logger.LogError($"view Usuario - {ex.Message}");
                return Json(jsonData);
            }

        }
        #endregion

        /// <summary>
        /// Paginação e ordenação
        /// </summary>
        /// <param name="lstElements"></param>
        /// <param name="requestFormData"></param>
        /// <returns></returns>
        private IEnumerable<UsuarioDTO> ProcessarDadosForm(IEnumerable<UsuarioDTO> lstElements, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };
                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = GetProperty(columName);
                        if (sortDirection == "asc")
                        {
                            return lstElements.OrderBy(prop.GetValue).Skip(skip)
                                .Take(pageSize).ToList();
                        }
                        else
                            return lstElements.OrderByDescending(prop.GetValue)
                                .Skip(skip).Take(pageSize).ToList();
                    }
                    else
                        return lstElements;
                }
            }
            return null;
        }

        private PropertyInfo GetProperty(string name)
        {
            var properties = typeof(UsuarioDTO).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

		[HttpGet()]
		public IActionResult Create()
		{
			ViewData["Title"] = "Cadastrar Novo Usuário";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(UsuarioDTO entityDTO)
		{

			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (ModelState.IsValid)
			{
				try
				{
                    //guardando a foto
					if (Request.Form.Files.Count > 0)
					{
						IFormFile file = Request.Form.Files.FirstOrDefault();
						using (var dataStream = new MemoryStream())
						{
							await file.CopyToAsync(dataStream);
							entityDTO.picture = dataStream.ToArray();
						}
					}

					//verificando se já existe o e-mail cadastrado
					var listaUsuarioDTO = await _usuarioService.GetAllAsync();
					string findEmail = listaUsuarioDTO.Select(x => x.email).FirstOrDefault(x => x == entityDTO.email);
					if (findEmail != null) return BadRequest(new { Message = "O email já existe." });


					//registrando no identty 
					var result = await _authentication.RegisterUserFull(entityDTO.email, entityDTO.password, entityDTO.nomePrimeiro, entityDTO.nomeUltimo, entityDTO.recebeEmail, entityDTO.picture);
					if (result)
					{
						
						Task<ApplicationUser> userSaved = _userManager.FindByEmailAsync(entityDTO.email);
                        UsuarioDTO usuarioDTO = new UsuarioDTO() {
                            UserId = userSaved.Result.Id,							
                            nomePrimeiro = userSaved.Result.FirstName,
                            nomeUltimo = userSaved.Result.LastName,
                            email= userSaved.Result.Email,
                            emailVerificado= userSaved.Result.EmailConfirmed,
                            recebeEmail= userSaved.Result.RecebeEmail,
                            ultimoAcesso= null,
                            ativo= true,
                            perfil= 1,
                            picture= userSaved.Result.Picture

						};


						await _usuarioService.CreateAsync(usuarioDTO);
						_logger.LogInformation($"Add Usuario - {entityDTO.email} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
					}
					//else
					//{
					//	var jsonData = new { Result = "ERROR", Message = "Tentativa inválida de registro." };
					//	_logger.LogError($"Add Usuario - {entityDTO.email} - Tentativa inválida de registro.");
					//	return Json(jsonData);
					//}
					
				}
				catch (Exception ex)
				{

					ModelState.AddModelError("CustomError", ex.Message);
					_logger.LogError($"Add Usuario - {entityDTO.email} - {ex.Message}");
					return View(entityDTO);
				}

				//return RedirectToAction(nameof(Index));
				return Redirect("/Usuario/Index");

			}
			return View(entityDTO);
		}

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var usuarioDTO = await _usuarioService.GetByIdAsync(id);
            if (usuarioDTO == null) return NotFound();
            return View(usuarioDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(UsuarioDTO usuario)
        {
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                try
                {
                    //validando se o email existe
                    var listaUsuarioDTO = await _usuarioService.GetAllAsync();
                    var usuarioFinded = listaUsuarioDTO.FirstOrDefault(x => x.email == usuario.email && x.id != usuario.id);
                    if (usuarioFinded != null)
                    {
                        ModelState.AddModelError("CustomError", "O email já existe.");
                        return View(usuario);                        
                    }


                    //atualizando no identty                     
                    var result = await _authentication.UpdateUser(usuario.email,usuario.password,usuario.nomePrimeiro, usuario.nomeUltimo,usuario.recebeEmail, usuario.picture);
                    if (result)
                    {                       
                        //atualizando usuario
                        await _usuarioService.UpdateAsync(usuario);
                        _logger.LogInformation($"Edit Usuario - {usuario.email} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

                    }
                    
                   
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("CustomError", ex.Message);
                    _logger.LogError($"Edit Usuario - {usuario.email} - {ex.Message}");
                    return View(usuario);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            UsuarioDTO usuarioDTOInfo = null;

            try
            {
                if (id == null) return NotFound();

                var usuarioDTO = await _usuarioService.GetByIdAsync(id);

                usuarioDTOInfo = usuarioDTO;

                if (usuarioDTO == null) return NotFound();

                //excluindo do identity
                await _authentication.DeleteUser(usuarioDTO.UserId);
                _logger.LogInformation($"Del Usuario identity - {usuarioDTO.UserId} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

                //excluindo usuario
                await _usuarioService.RemoveAsync(usuarioDTO);
                _logger.LogInformation($"Del Usuario - {usuarioDTO.email} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

                return this.Ok("O item foi excluido.");

            }
            catch (Exception ex)
            {
                //foreign key restrition
                if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
                {
                    _logger.LogError($"Del Usuario - {usuarioDTOInfo.email} - {ex.InnerException.Message}");
                    return BadRequest("O tipo de conquista esta sendo usado e não pode ser excluído.");
                }
                _logger.LogError($"Del Usuario - {usuarioDTOInfo.email} - {ex.Message}");
                return BadRequest(ex.Message);

            }

            return null;

        }

    }
}