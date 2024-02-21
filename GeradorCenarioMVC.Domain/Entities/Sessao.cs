using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Sessao : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Data { get; private set; }
        public int? DuracaoHoras { get; private set; }
        public bool? JogoOnline { get; private set; }
        public string Local { get; private set; }
        public string Vtt { get; private set; }
        public string YoutubeUrl { get; private set; }




        public Sessao(string titulo, string descricao, DateTime data, int? duracaoHoras, bool? jogoOnline, string local, string vtt, string youtubeUrl)
        {
            ValidateDomain(titulo, descricao, data, duracaoHoras, jogoOnline, local, vtt, youtubeUrl);
        }
        public Sessao(int id, string titulo, string descricao, DateTime data, int? duracaoHoras, bool? jogoOnline, string local, string vtt, string youtubeUrl)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(titulo, descricao, data, duracaoHoras, jogoOnline, local, vtt, youtubeUrl);
        }

        public void Update(string titulo, string descricao, DateTime data, int? duracaoHoras, bool? jogoOnline, string local, string vtt, string youtubeUrl,
                           int gmId, int grupoId, int enredoId)
        {
            ValidateDomain(titulo, descricao, data, duracaoHoras, jogoOnline, local, vtt, youtubeUrl);
            GmId = gmId;
            //GrupoId = grupoId;
            EnredoId = enredoId;
        }

        private void ValidateDomain(string titulo, string descricao, DateTime data, int? duracaoHoras, bool? jogoOnline, string local, string vtt, string youtubeUrl)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);
            DomainExceptionValidation.When(titulo?.Length < 3, "short", "titulo", "3");
            DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");
            DomainExceptionValidation.When(descricao?.Length > 255, "long", "descricao", "255");
            DomainExceptionValidation.When(!int.TryParse(duracaoHoras.ToString(), out int n), "invalid_number", "duracaoHoras", null);
            DomainExceptionValidation.When(!DateTime.TryParse(data.ToString(), out DateTime m), "invalid_date", "data", null);
            DomainExceptionValidation.When(local?.Length < 3, "short", "local", "3");
            DomainExceptionValidation.When(vtt?.Length < 3, "short", "vtt", "3");
            DomainExceptionValidation.When(youtubeUrl?.Length < 3, "short", "youtubeUrl", "3");

            Titulo = titulo;
            Descricao = descricao;
            Data = data;
            DuracaoHoras = duracaoHoras;
            JogoOnline = jogoOnline;
            Local = local;
            Vtt = vtt;
            YoutubeUrl = youtubeUrl;
        }

        
        public int GmId { get; set; }
        public Usuario Gm { get; set; }
        public int? GrupoId { get; set; }
        public Grupo Grupo { get; set; }
        public int EnredoId { get; set; }
        public Enredo Enredo { get; set; }
        //public int CampanhaId { get; set; }
        //public Campanha Campanha { get; set; }
        public ICollection<Missao> Missoes { get; set; }

    }
}