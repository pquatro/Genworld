using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class EnredoDTO : EntityDTO
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
        [DisplayName("Introdução")]
        [Required(ErrorMessage = "A Introducao é obrigatória.")]
        public string introducao { get; set; }
        /// <summary>
        /// Descrição sobre Organizações, segredos, e acontecimentos presentes que estão na atmosfera do enredo
        /// </summary>
        [DisplayName("Plano de Fundo")]
        [Required(ErrorMessage = "O Plano de Fundo é obrigatório.")]
        public string planoFundo { get; set; }
        /// <summary>
        /// Um resumo de toda aventura
        /// </summary>
        [DisplayName("Visão Geral")]
        [Required(ErrorMessage = "A Visão Geral é obrigatória.")]
        public string visaoGeral { get; set; }
        /// <summary>
        /// Como os personagens serão introduzidos na aventura
        /// </summary>
        [DisplayName("Gancho dos Personagens")]
        [Required(ErrorMessage = "O Gancho dos Personagens é obrigatório.")]
        public string ganchoPersonagens { get; set; }
        [DisplayName("Conclusão")]
        [Required(ErrorMessage = "A Conclusão é obrigatória.")]
        public string conclusao { get; set; }
        public string aliados { get; set; }
        [DisplayName("Campanha")]
        public int campanhaId { get; set; }
        public Campanha campanha { get; set; }
    }
}
