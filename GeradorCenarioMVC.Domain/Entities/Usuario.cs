using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Usuario : Entity
    {
        public string UserId { get; private set; }
        public string NomePrimeiro { get; private set; }
        public string NomeUltimo { get; private set; }
        //public string Login { get; private set; }
        //public string Senha { get; private set; }
        public string Email { get; private set; }
        public bool? EmailVerificado { get; private set; }
        public bool? RecebeEmail { get; private set; }        
        public bool? Ativo { get; private set; }
        public byte[]? Picture { get; private set; }
        public Perfil Perfil { get; private set; }


        public DateTime? UltimoAcesso { get; set; }



        public Usuario(int id, string userId, string nomePrimeiro, string nomeUltimo, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo, Perfil perfil, byte[]? picture)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            UserId = userId;
            Perfil = perfil;
            Picture = picture;
            ValidateDomain(nomePrimeiro, nomeUltimo, email, emailVerificado, recebeEmail, ultimoAcesso, ativo);
        }
        public Usuario(string userId, string nomePrimeiro, string nomeUltimo, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo, Perfil perfil, byte[]? picture)
        {
            UserId = userId;
            Perfil = perfil;
            Picture = picture;
          

             ValidateDomain(nomePrimeiro, nomeUltimo, email, emailVerificado, recebeEmail, ultimoAcesso, ativo);
        }

       
        public void Update(string nomePrimeiro, string nomeUltimo, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo, Perfil perfil)
        {
            ValidateDomain(nomePrimeiro, nomeUltimo, email, emailVerificado, recebeEmail, ultimoAcesso, ativo);
            Perfil = perfil;
        }

        protected void ValidateDomain(string nomePrimeiro, string nomeUltimo, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(nomePrimeiro), "blank", "nomePrimeiro", null);
            DomainExceptionValidation.When(nomePrimeiro.Any(Char.IsWhiteSpace), "whiteSpace", "nomePrimeiro", null);
            DomainExceptionValidation.When(nomePrimeiro?.Length > 50, "long", "nomePrimeiro", "50");
            DomainExceptionValidation.When(nomePrimeiro?.Length < 3, "short", "nomePrimeiro", "3");

            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeUltimo), "blank", "nomeUltimo", null);
            DomainExceptionValidation.When(nomeUltimo.Any(Char.IsWhiteSpace), "whiteSpace", "nomeUltimo", null);
            DomainExceptionValidation.When(nomeUltimo?.Length > 50, "long", "nomeUltimo", "50");
            DomainExceptionValidation.When(nomeUltimo?.Length < 3, "short", "nomeUltimo", "3");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "blank", "email", null);
            DomainExceptionValidation.When(email.Any(Char.IsWhiteSpace), "whiteSpace", "email", null);
            DomainExceptionValidation.When(email?.Length > 100, "long", "email", "100");
            DomainExceptionValidation.When(email?.Length < 3, "short", "email", "3");


            DomainExceptionValidation.When(ultimoAcesso!=null ? !DateTime.TryParse(ultimoAcesso.ToString(), out DateTime n) : false, "invalid_date", "ultimoAcesso", null);

            NomePrimeiro = nomePrimeiro;
            NomeUltimo = nomeUltimo;
            Email = email;
            EmailVerificado = emailVerificado;
            RecebeEmail = recebeEmail;
            UltimoAcesso = ultimoAcesso;
            Ativo = ativo;

        }       


        public ICollection<Pc> Pcs { get; set; }

        public ICollection<Sessao> Sessoes { get; set; }

    }
}