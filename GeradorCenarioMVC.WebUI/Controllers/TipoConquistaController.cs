using GeradorCenarioMVC.Application.DTOs;
using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Domain.Entities;
using GeradorCenarioMVC.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace GeradorCenarioMVC.WebUI.Controllers
{
    public class TipoConquistaController : Controller
    {
        private readonly ITipoConquistaService _tipoConquistaService;
        private readonly ILogger<HomeController> _logger;
        public TipoConquistaController(ITipoConquistaService tipoConquistaService, ILogger<HomeController> logger)
        {
            _tipoConquistaService = tipoConquistaService;
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
                var enumerableTipoConquista = await _tipoConquistaService.GetAllAsync();

                //paginação e ordenação
                IEnumerable<TipoConquistaDTO> listaForm = ProcessarDadosForm(enumerableTipoConquista, requestFormData);


                //busca
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                if (!string.IsNullOrEmpty(searchValue))
                {
                    listaForm = listaForm.Where(m =>
                                                m.id.ToString().Contains(searchValue)
                                             || m.nome.Contains(searchValue)
                                             || (m.ativo == true ? "sim" : "não").Contains(searchValue)
                    ).ToList<TipoConquistaDTO>();
                }


                var jsonData = new { draw = requestFormData["draw"], recordsFiltered = listaForm.Count<TipoConquistaDTO>(), recordsTotal = listaForm.Count<TipoConquistaDTO>(), data = listaForm };
                return Ok(jsonData);


            }
            catch (Exception ex)
            {
                var jsonData = new { Result = "ERROR", Message = ex.Message };
                _logger.LogError($"view TipoConquista - {ex.Message}");
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
        private IEnumerable<TipoConquistaDTO> ProcessarDadosForm(IEnumerable<TipoConquistaDTO> lstElements, IFormCollection requestFormData)
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
            var properties = typeof(TipoConquistaDTO).GetProperties();
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
            ViewData["Title"] = "Cadastrar Novo Tipo de Conquista";
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Create(TipoConquistaDTO tipoConquista)
        {

            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                try
                {
                    var listaTipoConquistaDTO = await _tipoConquistaService.GetAllAsync();
                    string findName = listaTipoConquistaDTO.Select(x => x.nome).FirstOrDefault(x => x == tipoConquista.nome);
					if (findName != null)
					{

						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};

						//ViewData["return"] = new { Result = "ERROR", Message = "O nome já existe." };
						return View(tipoConquista);
					}					

                    await _tipoConquistaService.CreateAsync(tipoConquista);
                    _logger.LogInformation($"Add TipoConquista - {tipoConquista.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
                }
                catch (Exception ex)
                {

                    var jsonData = new { Result = "ERROR", Message = ex.Message };
                    _logger.LogError($"Add TipoConquista - {tipoConquista.nome} - {ex.Message}");
                    return Json(jsonData);
                }

                //return RedirectToAction(nameof(Index));
				return Redirect("/TipoConquista/Index");

			}
            return View(tipoConquista);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var tipoConquistaDTO = await _tipoConquistaService.GetByIdAsync(id);
            if (tipoConquistaDTO == null) return NotFound();
            return View(tipoConquistaDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(TipoConquistaDTO tipoConquista)
        {
            //var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                try
                {

                    var listaTipoConquistaDTO = await _tipoConquistaService.GetAllAsync();
                    var tipoConquistaFinded = listaTipoConquistaDTO.FirstOrDefault(x => x.nome == tipoConquista.nome && x.id != tipoConquista.id);
                    if (tipoConquistaFinded != null)
                    {
						ViewData["MessageReturn"] = new MessageReturn()
						{
							Result = "ERROR",
							Message = "O nome já existe."
						};						
                        return View(tipoConquista);
                        //return BadRequest(new { Message = "O nome já existe." });
                    }

                    await _tipoConquistaService.UpdateAsync(tipoConquista);
                    _logger.LogInformation($"Edit TipoConquista - {tipoConquista.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("CustomError", ex.Message);
                    _logger.LogError($"Edit TipoConquista - {tipoConquista.nome} - {ex.Message}");
                    return View(tipoConquista);                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoConquista);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            TipoConquistaDTO tipoConquistaDTOInfo = null;

            try
            {
                if (id == null) return NotFound();

                var tipoConquistaDTO = await _tipoConquistaService.GetByIdAsync(id);

                tipoConquistaDTOInfo = tipoConquistaDTO;

                if (tipoConquistaDTO == null) return NotFound();

                await _tipoConquistaService.RemoveAsync(tipoConquistaDTO);

                _logger.LogInformation($"Del TipoConquista - {tipoConquistaDTO.nome} - user {HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)}");

                return this.Ok("O item foi excluido.");
                
            }
            catch (Exception ex)
            {
                //foreign key restrition
                if (ex.InnerException.Message.Contains("A instrução DELETE conflitou com a restrição do REFERENCE"))
                {
                    _logger.LogError($"Del TipoConquista - {tipoConquistaDTOInfo.nome} - {ex.InnerException.Message}");
                    return BadRequest("O tipo de conquista esta sendo usado e não pode ser excluído.");
                }
                _logger.LogError($"Del TipoConquista - {tipoConquistaDTOInfo.nome} - {ex.Message}");
                return BadRequest(ex.Message);
               
            }

            return null;

        }

       

    }
}
