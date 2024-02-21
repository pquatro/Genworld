using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using GeradorCenarioMVC.Domain.Entities;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class PcDTO : EntityDTO
    {
        [DisplayName("Primeiro nome")]
        [Required(ErrorMessage = "O primeiro nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O primeiro nome não pode ser maior que 50 caracteres.")]
        public string nomePrimeiro { get; set; }
        [DisplayName("Último nome")]
        [Required(ErrorMessage = "O último nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O último nome não pode ser maior que 50 caracteres.")]
        public string nomeUltimo { get; set; }
        [DisplayName("Apelido")]
        [MaxLength(50, ErrorMessage = "O apelido não pode ser maior que 50 caracteres.")]
        public string apelido { get; set; }
        [DisplayName("Caracteristicas")]
        [MaxLength(255, ErrorMessage = "As Caracteristicas nome não podem ser maior que 255 caracteres.")]
        public string caracteristicas { get; set; }
        [DisplayName("Introducao")]
        [MaxLength(255, ErrorMessage = "A Introducao não pode ser maior que 255 caracteres.")]
        public string introducao { get; set; }
        [DisplayName("Raça")]
        [MaxLength(50, ErrorMessage = "A Raça não pode ser maior que 50 caracteres.")]
        public string raca { get; set; }
        [DisplayName("Tendencia")]
        [MaxLength(50, ErrorMessage = "A Tendencia não pode ser maior que 50 caracteres.")]
        public string tendencia { get; set; }
        [DisplayName("Nascimento")]
        [MaxLength(50, ErrorMessage = "O Nascimento não pode ser maior que 50 caracteres.")]
        public string nascimento { get; set; }
        [DisplayName("Gênero")]
        [MaxLength(50, ErrorMessage = "O Gênero não pode ser maior que 50 caracteres.")]
        public string genero { get; set; }
        [DisplayName("Olhos")]
        [MaxLength(50, ErrorMessage = "A informação dos Olhos não pode ser maior que 50 caracteres.")]
        public string olhos { get; set; }
        [DisplayName("Cabelo")]
        [MaxLength(50, ErrorMessage = "O Cabelo não pode ser maior que 50 caracteres.")]
        public string cabelo { get; set; }
        [DisplayName("Pele")]
        [MaxLength(50, ErrorMessage = "A Pele não pode ser maior que 50 caracteres.")]
        public string pele { get; set; }

        [DisplayName("Altura")]
        public Double? altura { get; set; }
        [DisplayName("Peso")]
        public Double? peso { get; set; }
        [DisplayName("NotasSecretas")]
        public string notasSecretas { get; set; }


        [DisplayName("Idade")]
        public int? idade { get; set; }
        [DisplayName("Journal")]
        public string journal { get; set; }
        [DisplayName("Frase")]
        public string frase { get; set; }
        [DisplayName("História")]
        public string historia { get; set; }

        [DisplayName("Jogador")]
        public int jogadorId { get; set; }
        public Usuario jogador { get; set; }
              
        

        [DisplayName("Galeria")]
        public int? galeriaId { get; set; }
        public Galeria galeria { get; set; }
        [DisplayName("Imagem")]
        public int? imagemId { get; set; }
        public Imagem imagem { get; set; }
    }
}
