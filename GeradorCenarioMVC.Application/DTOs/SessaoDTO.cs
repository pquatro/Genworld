using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class SessaoDTO : EntityDTO
    {
        [DisplayName("Titulo")]
        [Required(ErrorMessage = "O Titulo é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Titulo não pode ser maior que 50 caracteres.")]
        public string titulo { get; set; }
        [DisplayName("Titulo")]        
        [MaxLength(255, ErrorMessage = "O Titulo não pode ser maior que 255 caracteres.")]
        public string descricao { get; set; }
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DisplayName("Data da sessão")]
        [Required(ErrorMessage = "A data da sessão é obrigatória.")]
        public DateTime data { get; set; }
        [DisplayName("Duração do jogo em horas")]
        public int? duracao { get; set; }
        [DisplayName("Jogo é online")]
        [DefaultValue(false)]
        public bool? online { get; set; }
        [DisplayName("Local")]
        public string local { get; set; }
        [DisplayName("Vtt")]
        [Url]
        public string vtt { get; set; }
        [DisplayName("Endereço do youtube")]
        [RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", ErrorMessage = "Endereço do YouTube não é válido.")]
        public string youtubeUrl { get; set; }
        [DisplayName("Mestre do jogo (GM)")]
        public int gmId { get; set; }
        public Usuario gm { get; set; }
               
        /*
        [DisplayName("Grupo")]
        public int? grupoId { get; set; }
        public Grupo grupo { get; set; }
        [DisplayName("Enredo")]
        public int enredoId { get; set; }
        public Enredo enredo { get; set; }
        */
    }
}


