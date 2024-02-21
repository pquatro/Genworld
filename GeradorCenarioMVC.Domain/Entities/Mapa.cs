using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Mapa : Entity
    {
        public string Titulo { get; private set; }        
        public string Descricao { get; private set; }        
        public int? Peso { get; private set; }
        public bool? ExibirHomepageCenario { get; private set; }
        public bool? Publico { get; private set; }
        public string Legenda { get; private set; }

       


        public Mapa(string titulo, string descricao, int? peso, bool? exibirHomepageCenario, bool? publico, string legenda)
        {
            ValidateDomain(titulo, descricao, peso, exibirHomepageCenario, publico, legenda);
        }
        public Mapa(int id, string titulo, string descricao, int? peso, bool? exibirHomepageCenario, bool? publico, string legenda)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(titulo, descricao, peso, exibirHomepageCenario, publico, legenda);
        }

        public void Update(string titulo, string descricao, int? peso, bool? exibirHomepageCenario, bool? publico, string legenda, int imagemId, ICollection<Tag> tags)
        {
            ValidateDomain(titulo, descricao, peso, exibirHomepageCenario, publico, legenda);
            ImagemId = imagemId;            
            Tags = tags;
        }

        private void ValidateDomain(string titulo, string descricao, int? peso, bool? exibirHomepageCenario, bool? publico, string legenda)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);            
            DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");
            DomainExceptionValidation.When(descricao?.Length > 255, "long", "descricao", "255");
            DomainExceptionValidation.When(!int.TryParse(peso.ToString(), out int p), "invalid_number", "peso", null);
            DomainExceptionValidation.When(legenda?.Length > 255, "long", "legenda", "255");

            Titulo = titulo;
            Descricao = descricao;
            Peso = peso;
            ExibirHomepageCenario = exibirHomepageCenario;
            Publico = publico;
            Legenda = legenda;
        }



        public int ImagemId { get; private set; }
        public Imagem Imagem { get; set; }

        //public ICollection<Materia> Localizacoes { get; set; }
        //public ICollection<Materia> Organizacoes { get; set; }    

        public int? LocalizacaoId { get; set; }
        public Materia Localizacao { get; set; }
        public int? OrganizacaoId { get; set; }
        public Materia Organizacao { get; set; }


        public int? MateriaId { get; set; }
        public Materia Materia { get; set; }

        public int? CenarioId { get; set; }
        public Cenario Cenario { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}