using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Grupo : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

               

        public Grupo(string nome, string descricao)
        {
            ValidateDomain(nome, descricao);
        }
        public Grupo(int id, string nome, string descricao)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nome, descricao);
        }

        public void Update(string nome, string descricao, ICollection<Pc> pcs, ICollection<Npc> npcs)
        {
            ValidateDomain(nome,descricao);
            PCs = pcs;
            NPCs = npcs;
        }

        private void ValidateDomain(string nome, string descricao)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
            DomainExceptionValidation.When(nome?.Length < 3, "short", "nome", "3");
            DomainExceptionValidation.When(nome?.Length > 50, "long", "nome", "50");
                        
            DomainExceptionValidation.When(descricao?.Length > 255, "long", "descricao", "255");

            Nome = nome;
            Descricao = descricao;
        }

        public ICollection<Pc> PCs { get; set; }
        public ICollection<Npc> NPCs { get; set; }
        public ICollection<Sessao> Sessoes { get; set; }

        public ICollection<Campanha> Campanhas { get; set; }

    }
}