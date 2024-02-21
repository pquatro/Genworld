using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public abstract class Conteudo : Entity
    {
        public string Titulo { get; protected set; }
        public string Descricao { get; protected set; }
        public bool? ConteudoRestrito { get; protected set; }
        public bool? PermitirComentario { get; protected set; }


        public Conteudo() { }

        public Conteudo(string titulo, string descricao, bool? conteudoRestrito, bool? permitirComentario)
        {
            ValidateDomain(titulo, descricao, conteudoRestrito, permitirComentario);
        }
        public Conteudo(int id, string titulo, string descricao, bool? conteudoRestrito, bool? permitirComentario)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(titulo, descricao, conteudoRestrito, permitirComentario);
        }

        private void ValidateDomain(string titulo, string descricao, bool? conteudoRestrito, bool? permitirComentario)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);
            DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "blank", "descricao", null);

            Titulo = titulo;
            Descricao = descricao;
            ConteudoRestrito = conteudoRestrito;
            PermitirComentario = permitirComentario;

        }
    }
}
