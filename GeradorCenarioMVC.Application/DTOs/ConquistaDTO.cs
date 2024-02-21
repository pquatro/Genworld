using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class ConquistaDTO : EntityDTO
    {
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O título é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Titulo não pode ser maior que 50 caracteres.")]
        public string titulo { get; set; }
		[Required(ErrorMessage = "O Tipo de conquista é obrigatório")]
		[DisplayName("Tipo de conquista")]
        public int tipoConquistaId { get; set; }
		//[JsonIgnore]
		public TipoConquista tipoConquista { get; set; }		
	}
}
