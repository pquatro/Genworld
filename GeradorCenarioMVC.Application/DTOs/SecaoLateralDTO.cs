using System.ComponentModel;

namespace GeradorCenarioMVC.Application.DTOs
{
    public class SecaoLateralDTO : EntityDTO
    {
        [DisplayName("Css")]
        public string css { get; set; }
        [DisplayName("Topo")]
        public string topo { get; set; }
        [DisplayName("Painel Topo")]
        public string painelTopo { get; set; }
        [DisplayName("Painel Abaixo")]
        public string painelAbaixo { get; set; }
        [DisplayName("Abaixo")]
        public string abaixo { get; set; }
    }
}
