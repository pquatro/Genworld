using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
	public class CenarioGeneroController : Controller
	{
		private readonly ICenarioGeneroService _cenarioGeneroService;
		private readonly ILogger<HomeController> _logger;
		public CenarioGeneroController(ICenarioGeneroService cenarioGeneroService, ILogger<HomeController> logger)
		{
			_cenarioGeneroService = cenarioGeneroService;
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
				var enumerableCenarioGenero = await _cenarioGeneroService.GetAllAsync();

				//paginação e ordenação
				IEnumerable<CenarioGeneroDTO> listaForm = ProcessarDadosForm(enumerableCenarioGenero, requestFormData);


				//busca
				var searchValue = Request.Form["search[value]"].FirstOrDefault();
				if (!string.IsNullOrEmpty(searchValue))
				{
					listaForm = listaForm.Where(m =>
												m.id.ToString().Contains(searchValue)
											 || m.nome.Contains(searchValue)
											 || (m.ativo == true ? "sim" : "não").Contains(searchValue)
					).ToList<CenarioGeneroDTO>();
				}


				var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<CenarioGeneroDTO>(), recordsTotal = listaForm.Count<CenarioGeneroDTO>(), data = listaForm };
				return Ok(jsonData);


			}
			catch (Exception ex)
			{
				var jsonData = new { Result = "ERROR", Message = ex.Message };
				_logger.LogError($"view CenarioGenero - {ex.Message}");
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
		private IEnumerable<CenarioGeneroDTO> ProcessarDadosForm(IEnumerable<CenarioGeneroDTO> lstElements, IFormCollection requestFormData)
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
			var properties = typeof(CenarioGeneroDTO).GetProperties();
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
			ViewData["Title"] = "Cadastrar Novo Gênero de Cenário";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Create(CenarioGeneroDTO cenarioGenero)
		{

			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (ModelState.IsValid)
			{
				try
				{
					var listaCenarioGeneroDTO = await _cenarioGeneroService.GetAllAsync();
					string findName = listaCenarioGeneroDTO.Select(x => x.nome).FirstOrDefault(x => x == cenarioGenero.nome);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						//ViewData["return"] = new { Result = "ERROR", Message = "O nome já existe." };
						return View(cenarioGenero);
					}					

					await _cenarioGeneroService.CreateAsync(cenarioGenero);
					_logger.LogInformation($"Add CenarioGenero - {cenarioGenero.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{

					var jsonData = new { Result = "ERROR", Message = ex.Message };
					_logger.LogError($"Add CenarioGenero - {cenarioGenero.nome} - {ex.Message}");
					return Json(jsonData);
				}

				//return RedirectToAction(nameof(Index));
				return Redirect("/CenarioGenero/Index");

			}
			return View(cenarioGenero);
		}

		[HttpGet()]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var cenarioGeneroDTO = await _cenarioGeneroService.GetByIdAsync(id);
			if (cenarioGeneroDTO == null) return NotFound();
			return View(cenarioGeneroDTO);
		}

		[HttpPost()]
		public async Task<IActionResult> Edit(CenarioGeneroDTO cenarioGenero)
		{
			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (ModelState.IsValid)
			{
				try
				{

					var listaCenarioGeneroDTO = await _cenarioGeneroService.GetAllAsync();
					var cenarioGeneroFinded = listaCenarioGeneroDTO.FirstOrDefault(x => x.nome == cenarioGenero.nome && x.id != cenarioGenero.id);
					if (cenarioGeneroFinded != null)
					{
						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};
						return View(cenarioGenero);
						//return BadRequest(new { Message = "O nome já existe." });
					}

					await _cenarioGeneroService.UpdateAsync(cenarioGenero);
					_logger.LogInformation($"Edit CenarioGenero - {cenarioGenero.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("CustomError", ex.Message);
					_logger.LogError($"Edit CenarioGenero - {cenarioGenero.nome} - {ex.Message}");
					return View(cenarioGenero);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(cenarioGenero);
		}

		[HttpGet()]
		public async Task<IActionResult> Delete(int? id)
		{
			CenarioGeneroDTO cenarioGeneroDTOInfo = null;

			try
			{
				if (id == null) return NotFound();

				var cenarioGeneroDTO = await _cenarioGeneroService.GetByIdAsync(id);

				cenarioGeneroDTOInfo = cenarioGeneroDTO;

				if (cenarioGeneroDTO == null) return NotFound();

				await _cenarioGeneroService.RemoveAsync(cenarioGeneroDTO);

				_logger.LogInformation($"Del CenarioGenero - {cenarioGeneroDTO.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

				return this.Ok("O item foi excluido.");

			}
			catch (Exception ex)
			{
				//foreign key restrition
				if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
				{
					_logger.LogError($"Del CenarioGenero - {cenarioGeneroDTOInfo.nome} - {ex.InnerException.Message}");
					return BadRequest("O gênero do Cenário esta sendo usado e não pode ser excluído.");
				}
				_logger.LogError($"Del CenarioGenero - {cenarioGeneroDTOInfo.nome} - {ex.Message}");
				return BadRequest(ex.Message);

			}

			return null;

		}



	}
}

