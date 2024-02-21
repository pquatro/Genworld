using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Cenario : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool? Privado { get; private set; }
        /// <summary>
        /// Peso para busca e ordem de preferência
        /// </summary>
        public int? Peso { get; private set; }
        public bool Ativo { get; private set; }
        /// <summary>
        /// Data presente do cenário
        /// </summary>
        public string DataCenario { get; private set; }
        public string SistemaOficial { get; private set; }
        public string CenarioOficial { get; private set; }



        public Cenario(string nome, string descricao, bool? privado, int? peso, bool ativo, string dataCenario, string sistemaOficial, string cenarioOficial)
        {
            ValidateDomain(nome, descricao, privado, peso, ativo, dataCenario, sistemaOficial, cenarioOficial);
        }
        public Cenario(int id, string nome, string descricao, bool? privado, int? peso, bool ativo, string dataCenario, string sistemaOficial, string cenarioOficial)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nome, descricao, privado, peso, ativo, dataCenario, sistemaOficial, cenarioOficial);
        }

        public void Update(string nome, string descricao, bool? privado, int? peso, bool ativo, string dataCenario, string sistemaOficial, string cenarioOficial, ICollection<Campanha> campanhas, ICollection<Materia> materias, ICollection<Mapa> mapas, ICollection<CenarioGenero> cenarioGeneros, ICollection<Tag> tags)
        {
            ValidateDomain(nome, descricao, privado, peso, ativo, dataCenario, sistemaOficial, cenarioOficial);
            //GaleriaId = galeriaId;
            Campanhas = campanhas;
            Materias = materias;
            Mapas = mapas;
            CenarioGeneros = cenarioGeneros;
            Tags = tags;
        }



        private void ValidateDomain(string nome, string descricao, bool? privado, int? peso, bool ativo, string dataCenario, string sistemaOficial, string cenarioOficial)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
            DomainExceptionValidation.When(nome?.Length > 50, "long", "nome", "50");
            DomainExceptionValidation.When(descricao?.Length < 3, "short", "descricao", "3");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "blank", "descricao", null);
            DomainExceptionValidation.When(!double.TryParse(peso.ToString(), out double p), "invalid_number", "peso", null);
            DomainExceptionValidation.When(sistemaOficial?.Length > 50, "long", "sistemaOficial", "50");
            DomainExceptionValidation.When(cenarioOficial?.Length > 50, "long", "cenarioOficial", "50");


            Nome = nome;
            Descricao = descricao;
            Privado = privado;
            Peso = peso;
            Ativo = ativo;
            DataCenario = dataCenario;
            SistemaOficial = sistemaOficial;
            CenarioOficial = cenarioOficial;
        }


        public int? GaleriaId { get; set; }
        public Galeria Galeria { get; set; }
        public ICollection<Campanha> Campanhas { get; set; }
        public ICollection<Materia> Materias { get; set; }
        public ICollection<Mapa> Mapas { get; set; }
        public ICollection<CenarioGenero> CenarioGeneros { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
