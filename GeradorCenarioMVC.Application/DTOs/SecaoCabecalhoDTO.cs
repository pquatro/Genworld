using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class SecaoCabecalhoDTO : EntityDTO
    {
        [DisplayName("Css")]
        public string css { get; set; }
        [DisplayName("SubCabeçalho")]
        public string subCabecalho { get; set; }
        [DisplayName("Créditos")]
        public string creditos { get; set; }
    }
}
