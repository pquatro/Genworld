using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Application.Services;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
	[Authorize]
	public class CenarioController : Controller
	{
		private readonly ICenarioService _cenarioService;
		private readonly ICenarioGeneroService _cenarioGeneroService;
		private readonly IWebHostEnvironment _environment;
		private readonly ILogger<HomeController> _logger;
		public CenarioController(ICenarioService cenarioService, ICenarioGeneroService cenarioGeneroService,
			IWebHostEnvironment environment, ILogger<HomeController> logger)
		{
			_cenarioService = cenarioService;
			_cenarioGeneroService = cenarioGeneroService;
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

			List<SelectListItem> items = new SelectList(await _cenarioGeneroService.GetAllAsync(), "id", "nome").ToList();
			//items.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.CenarioGeneros = items;

			ViewData["Title"] = "Cadastrar um Novo Cenário";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Create(CenarioDTO cenario)
		{

			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			List<SelectListItem> items = new SelectList(await _cenarioGeneroService.GetAllAsync(), "id", "nome").ToList();
			//items.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.CenarioGeneros = items;


			ModelState.Remove("sistemaOficial");
			ModelState.Remove("cenarioOficial");
			ModelState.Remove("cenarioGeneros");
			ModelState.Remove("tags");
			ModelState.Remove("peso");
			ModelState.Remove("galeria");
			ModelState.Remove("dataCenario");

			ModelState.Remove("tagsSelected");
			ModelState.Remove("MultipleFiles");


			if (ModelState.IsValid)
			{
				try
				{

					
					List<Imagem> imagens = await UploadImage(cenario.multipleFiles);
					Galeria gallery = new Galeria();
					gallery.Imagens = imagens;



					var listaCenarioDTO = await _cenarioService.GetAllAsync();
					string findName = listaCenarioDTO.Select(x => x.nome).FirstOrDefault(x => x == cenario.nome);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};
						return View(cenario);
					}

					cenario.galeria = gallery;
					cenario.dataCenario = DateTime.Now.ToString();

					List<CenarioGenero> cenarioGeneros = new List<CenarioGenero>();
					foreach (var item in cenario.cenarioGenerosSelected)
					{
						CenarioGeneroDTO obj = await _cenarioGeneroService.GetByIdAsync(Int32.Parse(item));
						CenarioGenero obj2 = new CenarioGenero(obj.id, obj.nome, obj.ativo);
						cenarioGeneros.Add(obj2);
					}
					cenario.cenarioGeneros = cenarioGeneros;


					if (cenario.tagsSelected.Count > 0)
					{
						List<Tag> tags = new List<Tag>();
						foreach (var item in cenario.tagsSelected)
						{
							Tag obj = new Tag(item);
							tags.Add(obj);
						}
						cenario.tags = tags;
					}


					await _cenarioService.UpdateAsync(cenario);
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

		private static async Task<List<Imagem>> UploadImage(IEnumerable<IFormFile> multipleFiles)
		{			

			try
			{
				List<Imagem> imagens = new List<Imagem>();
				if (multipleFiles != null) {
					foreach (var file in multipleFiles)
					{
						if (file.Length > 0)
						{
							// Process each file here
							//Creating a unique File Name
							var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
							var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);
							//Using Buffering
							//using (var stream = System.IO.File.Create(filePath))
							//{
							//    // The file is saved in a buffer before being processed
							//    await file.CopyToAsync(stream);
							//}
							//Using Streaming
							using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
							{
								//This will save to Local folder
								await file.CopyToAsync(stream);
							}
							// Create an instance of FileModel

							Imagem fileModel = new Imagem(uniqueFileName, filePath);
							imagens.Add(fileModel);
						}
					}
					return imagens;
				}
				
				return null;
			}
			catch (Exception ex)
			{
				throw;
			}
			
		}

		[HttpGet()]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var cenarioDTO = await _cenarioService.GetByIdAsync(id);
			if (cenarioDTO == null) return NotFound();

			
			var items = await _cenarioGeneroService.GetAllAsync();
			var selectList = new SelectList(items, "id", "nome", cenarioDTO.cenarioGeneros).ToList();
			//selectList.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.CenarioGeneros = selectList;
			

			return View(cenarioDTO);
		}

		[HttpPost()]
		public async Task<IActionResult> Edit(CenarioDTO cenario)
		{
			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


			var items = await _cenarioGeneroService.GetAllAsync();
			var selectList = new SelectList(items, "id", "nome", cenario.cenarioGeneros).ToList();
			//selectList.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.CenarioGeneros = selectList;


			ModelState.Remove("sistemaOficial");
			ModelState.Remove("cenarioOficial");
			ModelState.Remove("cenarioGeneros");
			ModelState.Remove("tags");
			ModelState.Remove("peso");

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

