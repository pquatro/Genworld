using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Tag : Entity
    {
        public string Nome { get; private set; }




        public Tag(string nome)
        {
            ValidateDomain(nome);
        }
        public Tag(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nome);
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
        public ICollection<Mapa> Mapas { get; set; }
    }
}
