using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
	[Authorize]
	public class CenarioController : Controller
	{
		private readonly ICenarioService _cenarioService;		
		private readonly IWebHostEnvironment _environment;
		private readonly ILogger<HomeController> _logger;
		public CenarioController(ICenarioService cenarioService, 
			IWebHostEnvironment environment, ILogger<HomeController> logger)
		{
			_cenarioService = cenarioService;			
			_environment = environment;
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
				var enumerableCenario = await _cenarioService.GetAllAsync();

				//paginação e ordenação
				IEnumerable<CenarioDTO> listaForm = ProcessarDadosForm(enumerableCenario, requestFormData);


				//busca

				var searchValue = Request.Form["search[value]"].FirstOrDefault();
				if (!string.IsNullOrEmpty(searchValue))
				{
					listaForm = listaForm.Where(m =>
												m.id.ToString().Contains(searchValue)
											 || m.nome.Contains(searchValue)
											 || m.dataCenario.Contains(searchValue)
											 || m.sistemaOficial.Contains(searchValue)
											 || m.cenarioOficial.Contains(searchValue)
											 || m.ativo.ToString().Contains(searchValue)

					).ToList<CenarioDTO>();
				}


				IList<CenarioDTO> lstCenarios = new List<CenarioDTO>();
				foreach (var item in listaForm)
				{					
					lstCenarios.Add(new CenarioDTO { id = item.id, nome = item.nome,  dataCenario = item.dataCenario, cenarioOficial = item.cenarioOficial, sistemaOficial = item.sistemaOficial, ativo = item.ativo });
				}

				var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<CenarioDTO>(), recordsTotal = listaForm.Count<CenarioDTO>(), data = lstCenarios };
				return Ok(jsonData);


			}
			catch (Exception ex)
			{
				var jsonData = new { Result = "ERROR", Message = ex.Message };
				_logger.LogError($"view Conquista - {ex.Message}");
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
		private IEnumerable<CenarioDTO> ProcessarDadosForm(IEnumerable<CenarioDTO> lstElements, IFormCollection requestFormData)
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
			var properties = typeof(CenarioDTO).GetProperties();
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
		public async Task<IActionResult> Create()
		{
			
			ViewData["Title"] = "Cadastrar um Novo Cenário";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Create(CenarioDTO cenario)
		{

			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (ModelState.IsValid)
			{
				try
				{
					var listaCenarioDTO = await _cenarioService.GetAllAsync();
					string findName = listaCenarioDTO.Select(x => x.nome).FirstOrDefault(x => x == cenario.nome);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						//ViewData["return"] = new { Result = "ERROR", Message = "O nome já existe." };
						return View(cenario);
					}

					await _cenarioService.CreateAsync(cenario);
					_logger.LogInformation($"Add Cenario - {cenario.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ViewData["MessageReturn"] = new MessageReturn()
					{
						Result = "ERROR",
						Message = ex.Message
					};
					_logger.LogError($"Add Conquista - {cenario.nome} - {ex.Message}");
					return View(cenario);
				}

				//return RedirectToAction(nameof(Index));
				return Redirect("/Cenario/Index");

			}
			return View(cenario);
		}

		[HttpGet()]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var cenarioDTO = await _cenarioService.GetByIdAsync(id);
			if (cenarioDTO == null) return NotFound();
						

			return View(cenarioDTO);
		}

		[HttpPost()]
		public async Task<IActionResult> Edit(CenarioDTO cenario)
		{
			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
						

			if (ModelState.IsValid)
			{
				try
				{

					IEnumerable<CenarioDTO> listaCenarioDTO = await _cenarioService.GetAllAsync(); //.AsNoTracking()


					var cenarioFinded = listaCenarioDTO.FirstOrDefault(x => x.nome == cenario.nome && x.id != cenario.id);
					if (cenarioFinded != null)
					{
						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						return View(cenario);
					}

					await _cenarioService.UpdateAsync(cenario);
					_logger.LogInformation($"Edit Cenario - {cenario.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ViewData["MessageReturn"] = new MessageReturn()
					{
						Result = "ERROR",
						Message = ex.Message
					};

					_logger.LogError($"Edit Cenario - {cenario.nome} - {ex.Message}");
					return View(cenario);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(cenario);
		}

		[HttpGet()]
		public async Task<IActionResult> Delete(int? id)
		{
			CenarioDTO cenarioDTOInfo = null;

			try
			{
				if (id == null) return NotFound();

				var cenarioDTO = await _cenarioService.GetByIdAsync(id);

				cenarioDTOInfo = cenarioDTO;

				if (cenarioDTO == null) return NotFound();

				await _cenarioService.RemoveAsync(cenarioDTO);

				_logger.LogInformation($"Del Cenario - {cenarioDTO.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

				return this.Ok("O item foi excluido.");

			}
			catch (Exception ex)
			{
				//foreign key restrition
				if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
				{
					_logger.LogError($"Del Cenario - {cenarioDTOInfo.nome} - {ex.InnerException.Message}");
					//return BadRequest("O tipo de conquista esta sendo usado e não pode ser excluído.");
				}
				_logger.LogError($"Del Cenario - {cenarioDTOInfo.nome} - {ex.Message}");
				return BadRequest(ex.Message);

			}

			return null;

		}
	}
}

