using GeradorCenarioMVC.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
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

		[DisplayName("Privado")]
		[DefaultValue(false)]
		public bool privado { get; set; }

		[DisplayName("Ativo")]
        [DefaultValue(true)]
        public bool ativo { get; set; }

		[DisplayName("Peso")]
		[Range(1, 99, ErrorMessage = "O Peso deve ser entre 1 e 99.")]
		public int? peso { get; set; }
        		
		public DateTime dataCriacao { get; set; }
		public string CriadoPorId { get; set; }
		

		[DisplayName("Sistema oficial")]
		public string sistemaOficial { get; set; }
		
        [DisplayName("Cenario oficial")]
		public string cenarioOficial { get; set; }

		
        public int? imagemId { get; set; }        
        public Imagem imagem { get; set; }


		public List<IFormFile> multipleFiles { get; set; }

		
		public List<Genero> generos { get; set; }
		[Required(ErrorMessage = "O gênero é obrigatório.")]
		public List<string> generosSelected { get; set; }

		//public List<Tag> tags { get; set; }

		//public List<string> tagsSelected { get; set; }
	}
}
