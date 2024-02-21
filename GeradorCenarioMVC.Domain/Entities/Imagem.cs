using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Imagem : Entity
    {
        public string Nome { get; private set; }
        public string Url { get; private set; }
        
        public Imagem(string nome, string url)
        {
            ValidateDomain(nome, url);
        }
        public Imagem(int id, string nome, string url)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nome, url);
        }

        public void Update(string nome, string url, ICollection<Galeria> galerias)
        {
            ValidateDomain(nome, url);
            Galerias = galerias;
        }

        private void ValidateDomain(string nome, string url)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
            DomainExceptionValidation.When(nome?.Length>50, "long", "nome", null);
            DomainExceptionValidation.When(!Uri.IsWellFormedUriString(url, UriKind.Absolute), "invalid_path", "url", null);

            Nome = nome;
            Url = url;
        }

        public ICollection<Galeria> Galerias { get; set; }
        public ICollection<Mapa> Mapas { get; set; }
        public ICollection<Npc> Npcs { get; set; }
        public ICollection<Pc> Pcs { get; set; }
        public ICollection<Campanha> Campanhas { get; set; }
        public ICollection<SecaoCabecalho> SecoesCabecalho { get; set; }

    }
}