using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class TipoMateriaDTO : EntityDTO
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Nome não pode ser maior que 50 caracteres.")]
        public string nome { get; set; }
        [DisplayName("Ativo")]
        [DefaultValue(true)]
        public bool? ativo { get; set; }
    }
}
