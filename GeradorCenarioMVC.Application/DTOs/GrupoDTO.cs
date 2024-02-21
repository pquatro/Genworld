using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class GrupoDTO : EntityDTO
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string nome { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A descrição não pode ser maior que 255 caracteres.")]
        public string descricao { get; set; }
    }
}
