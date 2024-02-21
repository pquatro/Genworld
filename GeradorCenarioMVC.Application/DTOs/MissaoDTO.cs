using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class MissaoDTO : EntityDTO
    {
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O Titulo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Titulo não pode ser maior que 50 caracteres.")]
        public string titulo { get; set; }
        [DisplayName("Resumo")]
        [Required(ErrorMessage = "O Resumo é obrigatório.")]
        public string resumo { get; set; }
        [DisplayName("Resolução")]
        public string resolucao { get; set; }
        [DisplayName("Notas secretas")]
        public string notasSecretas { get; set; }
        [DisplayName("Satus da missão")]
        public int statusMissaoId { get; private set; }
        public StatusMissao statusMissao { get; private set; }
        [DisplayName("Tipo de missão")]
        public int tipoMissaoId { get; private set; }
        public TipoMissao tipoMissao { get; private set; }
    }
}
