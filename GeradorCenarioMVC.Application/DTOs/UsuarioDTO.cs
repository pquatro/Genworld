using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class UsuarioDTO : EntityDTO
    {
        [DisplayName("Primeiro Nome")]
        [Required(ErrorMessage = "O Primeiro Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Primeiro Nome não pode ser maior que 50 caracteres.")]
        public string nome { get; set; }

        [DisplayName("Último Nome")]
        [Required(ErrorMessage = "O Último Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O Último Nome não pode ser maior que 50 caracteres.")]
        public string sobrenome { get; set; }       

        [DisplayName("Email")]
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Email não pode ser maior que 100 caracteres.")]		
		[EmailAddress(ErrorMessage = "O Email não é válido.")]
        public string email { get; set; }
        		
		[Required]
		[DataType(DataType.Password)]
		public string password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirmar password")]
		[Compare("password", ErrorMessage = "Passwords não são iguais")]
		public string confirmPassword { get; set; }


		[DisplayName("Email verificado")]
        [DefaultValue(false)]
        public bool? emailVerificado { get; set; }        

        [DisplayName("RecebeEmail")]
        [DefaultValue(true)]
        public bool? recebeEmail { get; set; }

        //[DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DisplayName("Último acesso")]
        public DateTime? ultimoAcesso { get; set; }

        [DisplayName("Ativo")]
        [DefaultValue(true)]
        public bool? ativo { get; set; }

        [DisplayName("Foto")]        
        public byte[]? FotoBytes { get; set; }

        public int? perfil { get; set; } = 1;

        public string? UserId { get; set; }




    }
}
