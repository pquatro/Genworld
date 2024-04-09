using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
	public class GeneroController : Controller
	{
		private readonly IGeneroService _generoService;
		private readonly ILogger<HomeController> _logger;
		public GeneroController(IGeneroService generoService, ILogger<HomeController> logger)
		{
			_generoService = generoService;
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
				var enumerableGenero = await _generoService.GetAllAsync();

				//paginação e ordenação
				IEnumerable<GeneroDTO> listaForm = ProcessarDadosForm(enumerableGenero, requestFormData);


				//busca
				var searchValue = Request.Form["search[value]"].FirstOrDefault();
				if (!string.IsNullOrEmpty(searchValue))
				{
					listaForm = listaForm.Where(m =>
												m.id.ToString().Contains(searchValue)
											 || m.nome.Contains(searchValue)
											 || (m.ativo == true ? "sim" : "não").Contains(searchValue)
					).ToList<GeneroDTO>();
				}


				var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<GeneroDTO>(), recordsTotal = listaForm.Count<GeneroDTO>(), data = listaForm };
				return Ok(jsonData);


			}
			catch (Exception ex)
			{
				var jsonData = new { Result = "ERROR", Message = ex.Message };
				_logger.LogError($"view Genero - {ex.Message}");
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
		private IEnumerable<GeneroDTO> ProcessarDadosForm(IEnumerable<GeneroDTO> lstElements, IFormCollection requestFormData)
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
			var properties = typeof(GeneroDTO).GetProperties();
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
			ViewData["Title"] = "Cadastrar Novo Gênero da Campanha";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Create(GeneroDTO genero)
		{

			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (ModelState.IsValid)
			{
				try
				{
					var listaGeneroDTO = await _generoService.GetAllAsync();
					string findName = listaGeneroDTO.Select(x => x.nome).FirstOrDefault(x => x == genero.nome);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						//ViewData["return"] = new { Result = "ERROR", Message = "O nome já existe." };
						return View(genero);
					}					

					await _generoService.CreateAsync(genero);
					_logger.LogInformation($"Add Genero - {genero.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{

					var jsonData = new { Result = "ERROR", Message = ex.Message };
					_logger.LogError($"Add Genero - {genero.nome} - {ex.Message}");
					return Json(jsonData);
				}

				//return RedirectToAction(nameof(Index));
				return Redirect("/Genero/Index");

			}
			return View(genero);
		}

		[HttpGet()]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var generoDTO = await _generoService.GetByIdAsync(id);
			if (generoDTO == null) return NotFound();
			return View(generoDTO);
		}

		[HttpPost()]
		public async Task<IActionResult> Edit(GeneroDTO genero)
		{
			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			if (ModelState.IsValid)
			{
				try
				{

					var listaGeneroDTO = await _generoService.GetAllAsync();
					var generoFinded = listaGeneroDTO.FirstOrDefault(x => x.nome == genero.nome && x.id != genero.id);
					if (generoFinded != null)
					{
						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};
						return View(genero);
						//return BadRequest(new { Message = "O nome já existe." });
					}

					await _generoService.UpdateAsync(genero);
					_logger.LogInformation($"Edit Genero - {genero.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("CustomError", ex.Message);
					_logger.LogError($"Edit Genero - {genero.nome} - {ex.Message}");
					return View(genero);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(genero);
		}

		[HttpGet()]
		public async Task<IActionResult> Delete(int? id)
		{
			GeneroDTO generoDTOInfo = null;

			try
			{
				if (id == null) return NotFound();

				var generoDTO = await _generoService.GetByIdAsync(id);

				generoDTOInfo = generoDTO;

				if (generoDTO == null) return NotFound();

				await _generoService.RemoveAsync(generoDTO);

				_logger.LogInformation($"Del Genero - {generoDTO.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

				return this.Ok("O item foi excluido.");

			}
			catch (Exception ex)
			{
				//foreign key restrition
				if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
				{
					_logger.LogError($"Del Genero - {generoDTOInfo.nome} - {ex.InnerException.Message}");
					return BadRequest("O gênero da Campanha esta sendo usado e não pode ser excluído.");
				}
				_logger.LogError($"Del Genero - {generoDTOInfo.nome} - {ex.Message}");
				return BadRequest(ex.Message);

			}

			return null;

		}



	}
}

