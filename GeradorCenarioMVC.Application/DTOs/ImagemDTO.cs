using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class ImagemDTO : EntityDTO
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string nome { get; set; }
        [DisplayName("URL")]
        [Required(ErrorMessage = "A URL é obrigatória.")]
        [MaxLength(100, ErrorMessage = "A URL não pode ser maior que 100 caracteres.")]
        [Url(ErrorMessage ="A URL não é válida.")]
        public string url { get; set; }
    }
}
