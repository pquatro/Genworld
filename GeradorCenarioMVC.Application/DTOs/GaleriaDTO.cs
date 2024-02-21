using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class GaleriaDTO : EntityDTO
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string nome { get; set; }
    }
}
