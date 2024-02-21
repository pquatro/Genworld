using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class MateriaDTO : EntityDTO
    {
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O Titulo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Titulo não pode ser maior que 50 caracteres.")]
        public string titulo { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A Descrição é obrigatória.")]
        public string descricao { get; set; }
        [DisplayName("Conjtúdo restrito")]
        [DefaultValue(false)]
        public bool? conteudoRestrito { get; set; }
        [DisplayName("Permitir comentários")]
        [DefaultValue(true)]
        public bool? permitirComentario { get; set; }
        [DisplayName("Peso")]
        [Range(1, 99, ErrorMessage = "O Peso deve ser entre 1 e 99.")]
        public int? peso { get; set; }
        [DisplayName("Exibir autor no topo.")]
        [DefaultValue(true)]
        public bool? exibirAutorTopo { get; set; }
        [DisplayName("Ícone")]
        public string icone { get; set; }
    }
}
