using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class CategoriaMateriaDTO : EntityDTO
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]        
        [MaxLength(50, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string nome { get; set; }
        [DisplayName("Ativo")]
        [DefaultValue(true)]
        public bool? ativo { get; set; }
        [DisplayName("Categoria materia parent")]
        public int? parentId { get; set; }
        public CategoriaMateria parent { get; set; }
    }
}
