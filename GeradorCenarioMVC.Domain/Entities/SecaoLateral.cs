using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class SecaoLateral : SecaoWeb
    {
        public string Topo { get; private set; }
        public string PainelTopo { get; private set; }
        public string PainelAbaixo { get; private set; }
        public string Abaixo { get; private set; }
        

        public SecaoLateral(string topo, string painelTopo, string painelAbaixo, string abaixo, string css)
        {
            ValidateDomain(topo, painelTopo, painelAbaixo, abaixo, css);
        }
        public SecaoLateral(int id, string topo, string painelTopo, string painelAbaixo, string abaixo, string css)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(topo, painelTopo, painelAbaixo, abaixo, css);
        }

        public void Update(string topo, string painelTopo, string painelAbaixo, string abaixo, string css)
        {
            ValidateDomain(topo, painelTopo, painelAbaixo, abaixo, css);            
        }

        private void ValidateDomain(string topo, string painelTopo, string painelAbaixo, string abaixo, string css)
        {

            DomainExceptionValidation.When(topo?.Length < 3, "short", "topo", "3");
            DomainExceptionValidation.When(painelTopo?.Length < 3, "short", "painelTopo", "3");
            DomainExceptionValidation.When(painelAbaixo?.Length < 3, "short", "painelAbaixo", "3");
            DomainExceptionValidation.When(abaixo?.Length < 3, "short", "abaixo", "3");
            DomainExceptionValidation.When(!Uri.IsWellFormedUriString(css, UriKind.Absolute), "invalid_path", "css", null);

            Topo = topo;
            PainelTopo = painelTopo;
            PainelAbaixo = painelAbaixo;
            Abaixo = abaixo;
            Css = css;
        }

        public ICollection<Materia> Materias { get; set; }
    }
}