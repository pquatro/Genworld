using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Application.Services;
using GeradorCenarioMVC.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
    [Authorize]
    public class ConquistaController : Controller
    {
		private readonly IConquistaService _conquistaService;
		private readonly ITipoConquistaService _tipoConquistaService;
		private readonly IWebHostEnvironment _environment;
		private readonly ILogger<HomeController> _logger;
		public ConquistaController(IConquistaService conquistaService, ITipoConquistaService tipoConquistaService, 
			IWebHostEnvironment environment, ILogger<HomeController> logger)
		{
			_conquistaService = conquistaService;
			_tipoConquistaService = tipoConquistaService;
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
				var enumerableConquista = await _conquistaService.GetAllAsync();
				
				//paginação e ordenação
				IEnumerable<ConquistaDTO> listaForm = ProcessarDadosForm(enumerableConquista, requestFormData);


				//busca
				
				var searchValue = Request.Form["search[value]"].FirstOrDefault();
				if (!string.IsNullOrEmpty(searchValue))
				{
					listaForm = listaForm.Where(m =>
												m.id.ToString().Contains(searchValue)
											 || m.titulo.Contains(searchValue)											 
					).ToList<ConquistaDTO>();
				}


				IList<ConquistaDTO>  lstConquistas = new List<ConquistaDTO>();
				foreach (var item in listaForm)
				{
					Domain.Entities.TipoConquista tipo = new Domain.Entities.TipoConquista(item.tipoConquista.Nome, item.tipoConquista.Ativo);					
					lstConquistas.Add(new ConquistaDTO { id = item.id, titulo = item.titulo, tipoConquista = tipo });	
				}

				var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<ConquistaDTO>(), recordsTotal = listaForm.Count<ConquistaDTO>(), data = lstConquistas };
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
		private IEnumerable<ConquistaDTO> ProcessarDadosForm(IEnumerable<ConquistaDTO> lstElements, IFormCollection requestFormData)
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
			var properties = typeof(ConquistaDTO).GetProperties();
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

			List<SelectListItem> items = new SelectList(await _tipoConquistaService.GetAllAsync(), "id", "nome").ToList();
			items.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.TipoConquistaId =items;

			

			ViewData["Title"] = "Cadastrar uma Nova Conquista";
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Create(ConquistaDTO conquista)
		{

			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			List<SelectListItem> items = new SelectList(await _tipoConquistaService.GetAllAsync(), "id", "nome").ToList();
			items.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.TipoConquistaId = items;

			ModelState.Remove("tipoConquista");

			if (conquista.tipoConquistaId==0)
			{
				ModelState.TryAddModelError(nameof(conquista.tipoConquistaId), "O Tipo de conquista é obrigatório");
			}



			if (ModelState.IsValid)
			{
				try
				{
					var listaConquistaDTO = await _conquistaService.GetAllAsync();
					string findName = listaConquistaDTO.Select(x => x.titulo).FirstOrDefault(x => x == conquista.titulo);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						//ViewData["return"] = new { Result = "ERROR", Message = "O nome já existe." };
						return View(conquista);
					}

					await _conquistaService.CreateAsync(conquista);
					_logger.LogInformation($"Add Conquista - {conquista.titulo} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{					
					ViewData["MessageReturn"] = new MessageReturn()
					{
						Result = "ERROR",
						Message = ex.Message
					};
					_logger.LogError($"Add Conquista - {conquista.titulo} - {ex.Message}");
					return View(conquista);
				}

				//return RedirectToAction(nameof(Index));
				return Redirect("/Conquista/Index");

			}			
			return View(conquista);
		}

		[HttpGet()]
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null) return NotFound();
			var conquistaDTO = await _conquistaService.GetByIdAsync(id);
			if (conquistaDTO == null) return NotFound();

			var items = await _tipoConquistaService.GetAllAsync();
			var selectList = new SelectList(items, "id", "nome", conquistaDTO.tipoConquistaId).ToList();
			selectList.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.TipoConquistaId = selectList;

			return View(conquistaDTO);
		}

		[HttpPost()]
		public async Task<IActionResult> Edit(ConquistaDTO conquista)
		{
			//var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

			var items = await _tipoConquistaService.GetAllAsync();
			var selectList = new SelectList(items, "id", "nome", conquista.tipoConquistaId).ToList();
			selectList.Insert(0, (new SelectListItem { Text = "-- selecione --", Value = "0" }));
			ViewBag.TipoConquistaId = selectList;

			ModelState.Remove("tipoConquista");

			if (conquista.tipoConquistaId == 0)
			{
				ModelState.TryAddModelError(nameof(conquista.tipoConquistaId), "O Tipo de conquista é obrigatório");
			}

			if (ModelState.IsValid)
			{
				try
				{

					IEnumerable<ConquistaDTO> listaConquistaDTO = await _conquistaService.GetAllAsync(); //.AsNoTracking()


					var conquistaFinded = listaConquistaDTO.FirstOrDefault(x => x.titulo == conquista.titulo && x.id != conquista.id);
					if (conquistaFinded != null)
					{
						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};
						
						return View(conquista);						
					}		
					
					await _conquistaService.UpdateAsync(conquista);
					_logger.LogInformation($"Edit Conquista - {conquista.titulo} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
				}
				catch (Exception ex)
				{
					ViewData["MessageReturn"] = new MessageReturn()
					{
						Result = "ERROR",
						Message = ex.Message
					};
					
					_logger.LogError($"Edit Conquista - {conquista.titulo} - {ex.Message}");
					return View(conquista);
				}
				return RedirectToAction(nameof(Index));
			}			
			return View(conquista);
		}

		[HttpGet()]
		public async Task<IActionResult> Delete(int? id)
		{
			ConquistaDTO conquistaDTOInfo = null;

			try
			{
				if (id == null) return NotFound();

				var conquistaDTO = await _conquistaService.GetByIdAsync(id);

				conquistaDTOInfo = conquistaDTO;

				if (conquistaDTO == null) return NotFound();

				await _conquistaService.RemoveAsync(conquistaDTO);

				_logger.LogInformation($"Del Conquista - {conquistaDTO.titulo} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

				return this.Ok("O item foi excluido.");

			}
			catch (Exception ex)
			{
				//foreign key restrition
				if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
				{
					_logger.LogError($"Del Conquista - {conquistaDTOInfo.titulo} - {ex.InnerException.Message}");
					return BadRequest("O tipo de conquista esta sendo usado e não pode ser excluído.");
				}
				_logger.LogError($"Del Conquista - {conquistaDTOInfo.titulo} - {ex.Message}");
				return BadRequest(ex.Message);

			}

			return null;

		}		
	}
}
