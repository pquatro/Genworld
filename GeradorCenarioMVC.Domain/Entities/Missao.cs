using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Missao : Entity
    {
        public string Titulo { get; private set; }
        public string Resumo { get; private set; }
        public string Resolucao { get; private set; }
        public string NotasSecretas { get; private set; }

        


        public Missao(string titulo, string resumo, string resolucao, string notasSecretas)
        {
            ValidateDomain(titulo, resumo, resolucao, notasSecretas);
        }
        public Missao(int id, string titulo, string resumo, string resolucao, string notasSecretas)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(titulo, resumo, resolucao, notasSecretas);
        }

        public void Update(string titulo, string resumo, string resolucao, string notasSecretas, int statusMissaoId, int tipoMissaoId)
        {
            ValidateDomain(titulo, resumo, resolucao, notasSecretas);
            StatusMissaoId = statusMissaoId;
            TipoMissaoId = tipoMissaoId;
        }

        private void ValidateDomain(string titulo, string resumo, string resolucao, string notasSecretas)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);
            DomainExceptionValidation.When(titulo?.Length < 3, "short", "titulo", "3");
            DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");
            DomainExceptionValidation.When(string.IsNullOrEmpty(resumo), "blank", "resumo", null);
            DomainExceptionValidation.When(string.IsNullOrEmpty(resolucao), "blank", "resolucao", null);

            Titulo = titulo;
            Resumo = resumo;
            Resolucao = resolucao;
            NotasSecretas = notasSecretas;
        }

        public int StatusMissaoId { get; private set; }
        public StatusMissao StatusMissao { get; private set; }
        public int TipoMissaoId { get; private set; }
        public TipoMissao TipoMissao { get; private set; }
        public ICollection<Sessao> Sessoes { get; set; }
    }
}