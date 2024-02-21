using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Conquista : Entity
    {
        public string Titulo { get; private set; }

        

        public Conquista(string titulo)
        {
            ValidateDomain(titulo);
        }
        public Conquista(int id, string titulo)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(titulo);
        }

        public void Update(string titulo, int tipoConquistaId)
        {
            ValidateDomain(titulo);
            TipoConquistaId = tipoConquistaId;
        }

        private void ValidateDomain(string titulo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);
            DomainExceptionValidation.When(titulo?.Length < 3, "short", "titulo", "3");
            DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");

            Titulo = titulo;
        }

        public int TipoConquistaId { get; set; }
        public TipoConquista TipoConquista { get; set; }

        public ICollection<Pc> Pcs { get; set; }

        public ICollection<Npc> Npcs { get; set; }
    }
}