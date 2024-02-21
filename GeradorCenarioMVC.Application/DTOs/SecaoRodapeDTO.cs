using GeradorCenarioMVC.Domain.Entities;
using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class SecaoRodapeDTO : EntityDTO
    {
        [DisplayName("Css")]
        public string css { get; set; }
        [DisplayName("Nota Rodapé")]
        public string notaRodape { get; set; }
        [DisplayName("Nota do Autor")]
        public string notaAutor { get; set; }
        [DisplayName("Comentários")]
        public string comentarios { get; set; }
        [DisplayName("Galeria")]
        public int? galeriaId { get; set; }
        public Galeria galeria { get; set; }
    }
}
