using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public class Materia : Conteudo
    {

        public int? Peso { get; protected set; }

        public bool? ExibirAutorTopo { get; protected set; }

        public string Icone { get; protected set; }



        public Materia() { }

        public Materia(string titulo, string descricao, int? peso, bool? conteudoRestrito, bool? exibirAutorTopo, bool? permitirComentario, string icone)
        {
            ValidateDomain(titulo, descricao, peso, conteudoRestrito, exibirAutorTopo, permitirComentario, icone);
        }
        public Materia(int id, string titulo, string descricao, int? peso, bool? conteudoRestrito, bool? exibirAutorTopo, bool? permitirComentario, string icone)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(titulo, descricao, peso, conteudoRestrito, exibirAutorTopo, permitirComentario, icone);
        }

        public void Update(string titulo, string descricao, int? peso, bool conteudoRestrito, bool exibirAutorTopo, bool permitirComentario, string icone,
                           int secaoCabecalhoId, int secaoRodapeId, int secaoLateralId, int categoriaId, int categoriaMateriaPaiId, int tipoMateriaId
                           )
        {
            ValidateDomain(titulo, descricao, peso, conteudoRestrito, exibirAutorTopo, permitirComentario, icone);
            //SecaoCabecalhoId = secaoCabecalhoId;
            //SecaoRodapeId = secaoRodapeId;
            //SecaoLateralId = secaoLateralId;            
            TipoMateriaId = tipoMateriaId;
        }



        private void ValidateDomain(string titulo, string descricao, int? peso, bool? conteudoRestrito, bool? exibirAutorTopo, bool? permitirComentario, string icone)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);
            DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "blank", "descricao", null);
            DomainExceptionValidation.When(!int.TryParse(peso.ToString(), out int p), "invalid_number", "peso", null);



            Titulo = titulo;
            Descricao = descricao;
            Peso = peso;
            ConteudoRestrito = conteudoRestrito;
            ExibirAutorTopo = exibirAutorTopo;
            PermitirComentario = permitirComentario;
            Icone = icone;
        }



        
        public int? SecaoCabecalhoId { get; set; }
        public SecaoCabecalho SecaoCabecalho { get; set; }
        public int? SecaoRodapeId { get; set; }
        public SecaoRodape SecaoRodape { get; set; }
        public int? SecaoLateralId { get; set; }
        public SecaoLateral SecaoLateral { get; set; }  
       
        public int TipoMateriaId { get; set; }
        public TipoMateria TipoMateria { get; set; }

        public int? ParentId { get; set; }
        public Materia Parent { get; set; }
        public ICollection<Materia>? SubMaterias { get; set; }

        public ICollection<Mapa> LocalizacaoMapas { get; set; }        
        public ICollection<Mapa> OrganizacaoMapas { get; set; }


        //public int MapaId { get; set; }
        //public Mapa Mapa { get; set; }

        public ICollection<Cenario> Cenarios { get; set; }
        public ICollection<CategoriaMateria> CategoriasMateria { get; set; }
    }
}
