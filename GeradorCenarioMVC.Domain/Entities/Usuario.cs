using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
	public sealed class Usuario : Entity
	{
		public string UserId { get; private set; }
		public string Nome { get; private set; }
		public string Sobrenome { get; private set; }		
		public string Email { get; private set; }
		public bool? EmailVerificado { get; private set; }
		public bool? RecebeEmail { get; private set; }
		public bool? Ativo { get; private set; }
		public byte[]? FotoBytes { get; private set; }
		public DateTime? UltimoAcesso { get; set; }

		public int PerfilId { get; private set; }

		/// <summary>
		/// Atributos de relacionamento
		/// </summary>

		//public ICollection<Pc> Pcs { get; set; }

		public int? FotoId { get; set; }
		public Imagem Foto { get; set; }

		public ICollection<Sessao> Sessoes { get; set; }
		public ICollection<Sessao> SessoesGm { get; set; }

		public ICollection<Campanha> Campanhas { get; set; }

		public ICollection<Campanha> CampanhasCriadoPor { get; set; }

		public ICollection<Campanha> CampanhasMestre { get; set; }

		//public int CampanhaId { get; set; }
		//public Campanha Campanha { get; set; }



		





		public Usuario(int id, string userId, string nome, string sobrenome, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo, int perfilId, byte[]? fotoBytes)
		{
			DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
			Id = id;
			UserId = userId;
			PerfilId = perfilId;
			FotoBytes = fotoBytes;
			ValidateDomain(nome, sobrenome, email, emailVerificado, recebeEmail, ultimoAcesso, ativo);
		}
		public Usuario(string userId, string nome, string sobrenome, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo, int perfilId, byte[]? fotoBytes)
		{
			UserId = userId;
			PerfilId = perfilId;
			FotoBytes = fotoBytes;


			ValidateDomain(nome, sobrenome, email, emailVerificado, recebeEmail, ultimoAcesso, ativo);
		}


		public void Update(string nome, string sobrenome, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo, int perfilId)
		{
			ValidateDomain(nome, sobrenome, email, emailVerificado, recebeEmail, ultimoAcesso, ativo);
			PerfilId = perfilId;
		}

		protected void ValidateDomain(string nome, string sobrenome, string email, bool? emailVerificado, bool? recebeEmail, DateTime? ultimoAcesso, bool? ativo)
		{

			DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nomePrimeiro", null);
			DomainExceptionValidation.When(nome.Any(Char.IsWhiteSpace), "whiteSpace", "nomePrimeiro", null);
			DomainExceptionValidation.When(nome?.Length > 50, "long", "nomePrimeiro", "50");
			DomainExceptionValidation.When(nome?.Length < 3, "short", "nomePrimeiro", "3");

			DomainExceptionValidation.When(string.IsNullOrEmpty(sobrenome), "blank", "nomeUltimo", null);
			DomainExceptionValidation.When(sobrenome.Any(Char.IsWhiteSpace), "whiteSpace", "nomeUltimo", null);
			DomainExceptionValidation.When(sobrenome?.Length > 50, "long", "nomeUltimo", "50");
			DomainExceptionValidation.When(sobrenome?.Length < 3, "short", "nomeUltimo", "3");

			DomainExceptionValidation.When(string.IsNullOrEmpty(email), "blank", "email", null);
			DomainExceptionValidation.When(email.Any(Char.IsWhiteSpace), "whiteSpace", "email", null);
			DomainExceptionValidation.When(email?.Length > 100, "long", "email", "100");
			DomainExceptionValidation.When(email?.Length < 3, "short", "email", "3");


			DomainExceptionValidation.When(ultimoAcesso != null ? !DateTime.TryParse(ultimoAcesso.ToString(), out DateTime n) : false, "invalid_date", "ultimoAcesso", null);

			Nome = nome;
			Sobrenome = sobrenome;
			Email = email;
			EmailVerificado = emailVerificado;
			RecebeEmail = recebeEmail;
			UltimoAcesso = ultimoAcesso;
			Ativo = ativo;

		}


		
	}
}
