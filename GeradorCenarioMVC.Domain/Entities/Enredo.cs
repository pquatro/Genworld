using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Enredo : Conteudo
    {
        public string Introducao { get; private set; }
        /// <summary>
        /// Descrição sobre Organizações, segredos, e acontecimentos presentes que estão na atmosfera do enredo
        /// </summary>
        public string PlanoFundo { get; private set; }
        /// <summary>
        /// Um resumo de toda aventura
        /// </summary>
        public string VisaoGeral { get; private set; }
        /// <summary>
        /// Como os personagens serão introduzidos na aventura
        /// </summary>
        public string GanchoPersonagens { get; private set; }
        public string Conclusao { get; private set; }
        public string Aliados { get; private set; }





        public Enredo(string titulo, string descricao, bool? conteudoRestrito, bool? permitirComentario,
                      string introducao, string planoFundo, string visaoGeral, string ganchoPersonagens, string conclusao, string aliados
                     )
        {
            ValidateDomain(titulo, descricao, conteudoRestrito, permitirComentario,
                      introducao, planoFundo, visaoGeral, ganchoPersonagens, conclusao, aliados);
        }
        public Enredo(int id, string titulo, string descricao, bool? conteudoRestrito, bool? permitirComentario,
                      string introducao, string planoFundo, string visaoGeral, string ganchoPersonagens, string conclusao, string aliados
                      )
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(titulo, descricao, conteudoRestrito, permitirComentario,
                      introducao, planoFundo, visaoGeral, ganchoPersonagens, conclusao, aliados
                          );
        }

        public void Update(string titulo, string descricao, bool? conteudoRestrito, bool? permitirComentario,
                           string introducao, string planoFundo, string visaoGeral, string ganchoPersonagens, string conclusao, string aliados, ICollection<Pc> personagens
                           )
        {
            ValidateDomain(titulo, descricao, conteudoRestrito, permitirComentario,
                          introducao, planoFundo, visaoGeral, ganchoPersonagens, conclusao, aliados
                          );
            Pcs = personagens;

        }

        private void ValidateDomain(string titulo, string descricao, bool? conteudoRestrito, bool? permitirComentario,
                      string introducao, string planoFundo, string visaoGeral, string ganchoPersonagens, string conclusao, string aliados
                                    )
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);
            DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "blank", "descricao", null);

            DomainExceptionValidation.When(string.IsNullOrEmpty(introducao), "blank", "introducao", null);
            DomainExceptionValidation.When(string.IsNullOrEmpty(planoFundo), "blank", "planoFundo", null);
            DomainExceptionValidation.When(string.IsNullOrEmpty(visaoGeral), "blank", "visaoGeral", null);
            DomainExceptionValidation.When(string.IsNullOrEmpty(ganchoPersonagens), "blank", "ganchoPersonagens", null);
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "conclusao", null);


            Titulo = titulo;
            Descricao = descricao;
            ConteudoRestrito = conteudoRestrito;
            PermitirComentario = permitirComentario;
            Introducao = introducao;
            PlanoFundo = planoFundo;
            VisaoGeral = visaoGeral;
            GanchoPersonagens = ganchoPersonagens;
            Conclusao = conclusao;
            Aliados = aliados;
        }

        //public int SessaoId { get; set; }
        //public Sessao Sessao { get; set; }
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }
        public ICollection<Pc> Pcs { get; set; }
        public ICollection<Sessao> Sessoes { get; set; }


        //public ICollection<Mapa> LocalizacaoMapas { get; set; }

        //public ICollection<Mapa> OrganizacaoMapas { get; set; }
    }
}