using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class CampanhaDTO : EntityDTO
    {
        [DisplayName("Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]                
        [MaxLength(50, ErrorMessage = "O nome não pode ser maior que 50 caracteres.")]
        public string nome { get; set; }
        [DisplayName("Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória.")]        
        public string descricao { get; set; }
        [DisplayName("Introdução")]
        [Required(ErrorMessage = "A introdução é obrigatória.")]
        public string introducao { get; set; }
        [DisplayName("Ativo")]
        [DefaultValue(true)]
        public bool? ativo { get; set; }
        [DisplayName("Imagem")]
        public int? imagemId { get; set; }        
        public Imagem imagem { get; set; }
        [DisplayName("Cenario")]
        public int cenarioId { get; set; }        
        public Cenario cenario { get; set; }
    }
}
