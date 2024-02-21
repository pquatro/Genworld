using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class MapaDTO : EntityDTO
    {
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O Titulo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Titulo não pode ser maior que 50 caracteres.")]
        public string titulo { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string descricao { get; set; }
        [DisplayName("Peso")]
        [Range(1, 99, ErrorMessage = "O Peso deve ser entre 1 e 99.")]
        public int? peso { get; set; }
        [DisplayName("Exibir na homepage do cenário.")]
        [DefaultValue(false)]
        public bool? exibirHomepageCenario { get; set; }
        [DisplayName("Público")]
        [DefaultValue(true)]
        public bool? publico { get; set; }
        [DisplayName("Legenda")]
        [MaxLength(255, ErrorMessage = "A Legenda não pode ser maior que 255 caracteres.")]
        public string legenda { get; set; }
        [DisplayName("Localização")]
        public int? localizacaoId { get; set; }
        public Materia localizacao { get; set; }
        [DisplayName("Organização")]
        public int? organizacaoId { get; set; }
        public Materia organizacao { get; set; }

        [DisplayName("Materia")]
        public int? materiaId { get; set; }
        public Materia materia { get; set; }
        [DisplayName("Cenário")]
        public int? cenarioId { get; set; }
        public Cenario cenario { get; set; }
    }
}
