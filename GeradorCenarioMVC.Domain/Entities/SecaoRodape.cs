using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class SecaoRodape : SecaoWeb
    {
        public string NotaRodape { get; private set; }
        public string NotaAutor { get; private set; }
        public string Comentarios { get; private set; }

        


        public SecaoRodape(string notaRodape, string notaAutor, string comentarios, string css)
        {
            ValidateDomain(notaRodape, notaAutor, comentarios, css);
        }
        public SecaoRodape(int id, string notaRodape, string notaAutor, string comentarios, string css)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(notaRodape, notaAutor, comentarios, css);
        }

        public void Update(string notaRodape, string notaAutor, string comentarios, string css, int galeriaId)
        {
            ValidateDomain(notaRodape, notaAutor, comentarios, css);
            //GaleriaId = galeriaId;
        }

        private void ValidateDomain(string notaRodape, string notaAutor, string comentarios, string css)
        {

            DomainExceptionValidation.When(notaRodape?.Length < 3, "short", "notaRodape", "3");
            DomainExceptionValidation.When(notaAutor?.Length < 3, "short", "notaAutor", "3");
            DomainExceptionValidation.When(comentarios?.Length < 3, "short", "comentarios", "3");
            DomainExceptionValidation.When(!Uri.IsWellFormedUriString(css, UriKind.Absolute), "invalid_path", "css", null);

            NotaRodape = notaRodape;
            NotaAutor = notaAutor;
            Comentarios = comentarios;
            Css = css;
        }


        public int? GaleriaId { get; set; }
        public Galeria Galeria { get; set; }
        public ICollection<Materia> Materias { get; set; }
    }
}