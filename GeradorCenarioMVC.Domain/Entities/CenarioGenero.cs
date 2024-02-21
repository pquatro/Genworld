using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class CenarioGenero : Entity
    {
        public string Nome { get; private set; }
        public bool? Ativo { get; private set; }


        public CenarioGenero(string nome)
        {
            ValidateDomain(nome);
        }
        public CenarioGenero(int id, string nome, bool? ativo)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nome);
            Ativo = ativo;
        }

        public void Update(string nome, ICollection<Cenario> cenarios)
        {
            ValidateDomain(nome);
            Cenarios = cenarios;
        }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
            DomainExceptionValidation.When(nome?.Length < 3, "short", "nome", "3");
            DomainExceptionValidation.When(nome?.Length > 50, "long", "nome", "50");

            Nome = nome;
        }

        public ICollection<Cenario> Cenarios { get; set; }

    }
}
