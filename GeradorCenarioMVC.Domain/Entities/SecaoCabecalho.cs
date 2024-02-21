using GeradorCenarioMVC.Domain.Validation;
using System;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class SecaoCabecalho : SecaoWeb
    {
        public string SubCabecalho { get; private set; }
        public string Creditos { get; private set; }


        

        public SecaoCabecalho(string subCabecalho, string creditos, string css)
        {
            ValidateDomain(subCabecalho, creditos, css);
        }
        public SecaoCabecalho(int id, string subCabecalho, string creditos, string css)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(subCabecalho, creditos, css);
        }

        public void Update(string subCabecalho, string creditos, string css, int imagemId)
        {
            ValidateDomain(subCabecalho, creditos, css);
            //ImagemId = imagemId;
        }

        private void ValidateDomain(string subCabecalho, string creditos, string css)
        {
            
            DomainExceptionValidation.When(subCabecalho?.Length < 3, "short", "subCabecalho", "3");
            DomainExceptionValidation.When(creditos?.Length < 3, "short", "creditos", "3");
            DomainExceptionValidation.When(!Uri.IsWellFormedUriString(css, UriKind.Absolute), "invalid_path", "css", null);

            SubCabecalho = subCabecalho;
            Creditos = creditos;
            Css = css;
        }

        //public int ImagemId { get; set; }
        //public Imagem Imagem { get; set; }        
        public ICollection<Materia> Materias { get; set; }
    }
}