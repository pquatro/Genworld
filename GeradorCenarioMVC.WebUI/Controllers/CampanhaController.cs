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
	public class CampanhaController : Controller
	{
		private readonly ICampanhaService _campanhaService;
		private readonly IGeneroService _generoService;
		private readonly IWebHostEnvironment _environment;
		private readonly ILogger<HomeController> _logger;
		public CampanhaController(ICampanhaService campanhaService, IGeneroService generoService,
			IWebHostEnvironment environment, ILogger<HomeController> logger)
		{
			_campanhaService = campanhaService;
			_generoService = generoService;
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
				var enumerableCampanha = await _campanhaService.GetAllAsync();

				//paginação e ordenação
				IEnumerable<CampanhaDTO> listaForm = ProcessarDadosForm(enumerableCampanha, requestFormData);


				//busca

				var searchValue = Request.Form["search[value]"].FirstOrDefault();
				if (!string.IsNullOrEmpty(searchValue))
				{
					listaForm = listaForm.Where(m =>
												m.id.ToString().Contains(searchValue)
											 || m.nome.Contains(searchValue)
											 || m.dataCriacao.ToShortDateString().Contains(searchValue)
											 || m.sistemaOficial.Contains(searchValue)
											 || m.cenarioOficial.Contains(searchValue)
											 || m.ativo.ToString().Contains(searchValue)

					).ToList<CampanhaDTO>();
				}


				IList<CampanhaDTO> lstCampanhas = new List<CampanhaDTO>();
				foreach (var item in listaForm)
				{					
					lstCampanhas.Add(new CampanhaDTO { id = item.id, nome = item.nome, dataCriacao = item.dataCriacao, cenarioOficial = item.cenarioOficial, sistemaOficial = item.sistemaOficial, ativo = item.ativo });
				}

				var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<CampanhaDTO>(), recordsTotal = listaForm.Count<CampanhaDTO>(), data = lstCampanhas };
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
		private IEnumerable<CampanhaDTO> ProcessarDadosForm(IEnumerable<CampanhaDTO> lstElements, IFormCollection requestFormData)
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
			var properties = typeof(CampanhaDTO).GetProperties();
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

			List<SelectListItem> items = new SelectList(await _generoService.GetAllAsync(), "id", "nome").ToList();
			//items.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.Generos = items;

			ViewData["Title"] = "Cadastrar uma Nova Campanha";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Create(CampanhaDTO campanha)
		{

			var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			List<SelectListItem> items = new SelectList(await _generoService.GetAllAsync(), "id", "nome").ToList();
			//items.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.Generos = items;


			ModelState.Remove("sistemaOficial");
			ModelState.Remove("campanhaOficial");
			//ModelState.Remove("generos");			
			ModelState.Remove("peso");			
			ModelState.Remove("dataCampanha");
			ModelState.Remove("tags");
			ModelState.Remove("tagsSelected");
			ModelState.Remove("MultipleFiles");


			List<Genero> generos = new List<Genero>();
			foreach (var item in campanha.generosSelected)
			{
				GeneroDTO obj = await _generoService.GetByIdAsync(Int32.Parse(item));
				Genero obj2 = new Genero(obj.id, obj.nome, obj.ativo);
				generos.Add(obj2);
			}
			campanha.generos = generos;
			campanha.CriadoPorId = userId;
			campanha.dataCriacao = DateTime.Now;


			if (ModelState.IsValid)
			{
				try
				{


					var listaCampanhaDTO = await _campanhaService.GetAllAsync();
					string findName = listaCampanhaDTO.Select(x => x.nome).FirstOrDefault(x => x == campanha.nome);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};
						return View(campanha);
					}

					Imagem imagem = await UploadImage(campanha.multipleFiles, campanha.nome);
					campanha.imagem = imagem;

					

					/*
					if (campanha.tagsSelected.Count > 0)
					{
						List<Tag> tags = new List<Tag>();
						foreach (var item in campanha.tagsSelected)
						{
							Tag obj = new Tag(item);
							tags.Add(obj);
						}
						campanha.tags = tags;
					}
					*/

					await _campanhaService.UpdateAsync(campanha);
					_logger.LogInformation($"Add Campanha - {campanha.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ViewData["MessageReturn"] = new MessageReturn()
					{
						Result = "ERROR",
						Message = ex.Message
					};
					_logger.LogError($"Add Conquista - {campanha.nome} - {ex.Message}");
					return View(campanha);
				}

				//return RedirectToAction(nameof(Index));
				return Redirect("/Campanha/Index");

			}
			return View(campanha);
		}

		private static async Task<Imagem> UploadImage(List<IFormFile> multipleFiles, string campanhaNome)
		{			

			try
			{
				
				if (multipleFiles != null) {
					Imagem fileModel = null;
					foreach (var file in multipleFiles)
					{
						if (file.Length > 0)
						{
							// Process each file here
							//Creating a unique File Name
							var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
							var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/" + campanhaNome, uniqueFileName);
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

							fileModel = new Imagem(uniqueFileName, filePath);							
						}
					}
					return fileModel;
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
			var campanhaDTO = await _campanhaService.GetByIdAsync(id);
			if (campanhaDTO == null) return NotFound();

			
			var items = await _generoService.GetAllAsync();
			var selectList = new SelectList(items, "id", "nome", campanhaDTO.generos).ToList();
			//selectList.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.Generos = selectList;
			

			return View(campanhaDTO);
		}

		[HttpPost()]
		public async Task<IActionResult> Edit(CampanhaDTO campanha)
		{
			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);


			var items = await _generoService.GetAllAsync();
			var selectList = new SelectList(items, "id", "nome", campanha.generos).ToList();
			//selectList.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.Generos = selectList;


			ModelState.Remove("sistemaOficial");
			ModelState.Remove("campanhaOficial");
			ModelState.Remove("generos");
			ModelState.Remove("tags");
			ModelState.Remove("peso");

			if (ModelState.IsValid)
			{
				try
				{

					IEnumerable<CampanhaDTO> listaCampanhaDTO = await _campanhaService.GetAllAsync(); //.AsNoTracking()


					var campanhaFinded = listaCampanhaDTO.FirstOrDefault(x => x.nome == campanha.nome && x.id != campanha.id);
					if (campanhaFinded != null)
					{
						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						return View(campanha);
					}

					await _campanhaService.UpdateAsync(campanha);
					_logger.LogInformation($"Edit Campanha - {campanha.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ViewData["MessageReturn"] = new MessageReturn()
					{
						Result = "ERROR",
						Message = ex.Message
					};

					_logger.LogError($"Edit Campanha - {campanha.nome} - {ex.Message}");
					return View(campanha);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(campanha);
		}

		[HttpGet()]
		public async Task<IActionResult> Delete(int? id)
		{
			CampanhaDTO campanhaDTOInfo = null;

			try
			{
				if (id == null) return NotFound();

				var campanhaDTO = await _campanhaService.GetByIdAsync(id);

				campanhaDTOInfo = campanhaDTO;

				if (campanhaDTO == null) return NotFound();

				await _campanhaService.RemoveAsync(campanhaDTO);

				_logger.LogInformation($"Del Campanha - {campanhaDTO.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

				return this.Ok("O item foi excluido.");

			}
			catch (Exception ex)
			{
				//foreign key restrition
				if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
				{
					_logger.LogError($"Del Campanha - {campanhaDTOInfo.nome} - {ex.InnerException.Message}");
					//return BadRequest("O tipo de conquista esta sendo usado e não pode ser excluído.");
				}
				_logger.LogError($"Del Campanha - {campanhaDTOInfo.nome} - {ex.Message}");
				return BadRequest(ex.Message);

			}

			return null;

		}
	}
}

