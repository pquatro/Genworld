using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
	public class CategoriaMateriaController : Controller
	{
		private readonly ICategoriaMateriaService _categoriaMateriaService;
		private readonly ILogger<HomeController> _logger;
		public CategoriaMateriaController(ICategoriaMateriaService categoriaMateriaService, ILogger<HomeController> logger)
		{
			_categoriaMateriaService = categoriaMateriaService;
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
				var enumerableCategoriaMateria = await _categoriaMateriaService.GetAllAsync();

				//paginação e ordenação
				IEnumerable<CategoriaMateriaDTO> listaForm = ProcessarDadosForm(enumerableCategoriaMateria, requestFormData);


				//busca
				var searchValue = Request.Form["search[value]"].FirstOrDefault();
				if (!string.IsNullOrEmpty(searchValue))
				{
					listaForm = listaForm.Where(m =>
												m.id.ToString().Contains(searchValue)
											 || m.nome.Contains(searchValue)
											 || (m.ativo == true ? "sim" : "não").Contains(searchValue)
					).ToList<CategoriaMateriaDTO>();
				}


				var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<CategoriaMateriaDTO>(), recordsTotal = listaForm.Count<CategoriaMateriaDTO>(), data = listaForm };
				return Ok(jsonData);


			}
			catch (Exception ex)
			{
				var jsonData = new { Result = "ERROR", Message = ex.Message };
				_logger.LogError($"view CategoriaMateria - {ex.Message}");
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
		private IEnumerable<CategoriaMateriaDTO> ProcessarDadosForm(IEnumerable<CategoriaMateriaDTO> lstElements, IFormCollection requestFormData)
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
			var properties = typeof(CategoriaMateriaDTO).GetProperties();
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
			ViewData["Title"] = "Cadastrar Nova Categoria de Materia";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Create(CategoriaMateriaDTO categoriaMateria)
		{

			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			ModelState.Remove("parent");

			if (ModelState.IsValid)
			{
				try
				{
					var listaCategoriaMateriaDTO = await _categoriaMateriaService.GetAllAsync();
					string findName = listaCategoriaMateriaDTO.Select(x => x.nome).FirstOrDefault(x => x == categoriaMateria.nome);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						//ViewData["return"] = new { Result = "ERROR", Message = "O nome já existe." };
						return View(categoriaMateria);
					}

					await _categoriaMateriaService.CreateAsync(categoriaMateria);
					_logger.LogInformation($"Add CategoriaMateria - {categoriaMateria.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{

					var jsonData = new { Result = "ERROR", Message = ex.Message };
					_logger.LogError($"Add CategoriaMateria - {categoriaMateria.nome} - {ex.Message}");
					return Json(jsonData);
				}

				//return RedirectToAction(nameof(Index));
				return Redirect("/CategoriaMateria/Index");

			}
			return View(categoriaMateria);
		}

		[HttpGet()]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var categoriaMateriaDTO = await _categoriaMateriaService.GetByIdAsync(id);
			if (categoriaMateriaDTO == null) return NotFound();
			return View(categoriaMateriaDTO);
		}

		[HttpPost()]
		public async Task<IActionResult> Edit(CategoriaMateriaDTO categoriaMateria)
		{
			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			ModelState.Remove("parent");

			if (ModelState.IsValid)
			{
				try
				{

					var listaCategoriaMateriaDTO = await _categoriaMateriaService.GetAllAsync();
					var categoriaMateriaFinded = listaCategoriaMateriaDTO.FirstOrDefault(x => x.nome == categoriaMateria.nome && x.id != categoriaMateria.id);
					if (categoriaMateriaFinded != null)
					{
						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};
						return View(categoriaMateria);
						//return BadRequest(new { Message = "O nome já existe." });
					}

					await _categoriaMateriaService.UpdateAsync(categoriaMateria);
					_logger.LogInformation($"Edit CategoriaMateria - {categoriaMateria.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("CustomError", ex.Message);
					_logger.LogError($"Edit CategoriaMateria - {categoriaMateria.nome} - {ex.Message}");
					return View(categoriaMateria);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(categoriaMateria);
		}

		[HttpGet()]
		public async Task<IActionResult> Delete(int? id)
		{
			CategoriaMateriaDTO categoriaMateriaDTOInfo = null;

			try
			{
				if (id == null) return NotFound();

				var categoriaMateriaDTO = await _categoriaMateriaService.GetByIdAsync(id);

				categoriaMateriaDTOInfo = categoriaMateriaDTO;

				if (categoriaMateriaDTO == null) return NotFound();

				await _categoriaMateriaService.RemoveAsync(categoriaMateriaDTO);

				_logger.LogInformation($"Del CategoriaMateria - {categoriaMateriaDTO.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

				return this.Ok("O item foi excluido.");

			}
			catch (Exception ex)
			{
				//foreign key restrition
				if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
				{
					_logger.LogError($"Del CategoriaMateria - {categoriaMateriaDTOInfo.nome} - {ex.InnerException.Message}");
					return BadRequest("O tipo de conquista esta sendo usado e não pode ser excluído.");
				}
				_logger.LogError($"Del CategoriaMateria - {categoriaMateriaDTOInfo.nome} - {ex.Message}");
				return BadRequest(ex.Message);

			}

			return null;

		}



	}
}
