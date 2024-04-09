using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
	public sealed class Campanha : Entity
	{
		public string Nome { get; private set; }
		public string Descricao { get; private set; }
		public bool Privado { get; private set; }
		public int? Peso { get; private set; }
		public bool Ativo { get; private set; }
		public DateTime DataCriacao { get; private set; }		
		public string Sistema { get; private set; }
		public string Cenario { get; private set; }
		public int StatusCampanhaId { get; private set; }

		/// <summary>
		/// Atributos de relacionamento
		/// </summary>

		//public ICollection<Tag> Tags { get; set; }
		public int CriadoPorId { get; set; }
		public Usuario CriadoPor { get; set; }
		public int? ImagemId { get; set; }
		public Imagem Imagem { get; set; }

		public int MestreId { get; set; }
		public Usuario Mestre { get; set; }		
		
		public ICollection<Sessao> Sessoes { get; set; }
		public ICollection<Usuario> Usuarios { get; set; }
		public ICollection<Genero> Generos { get; set; }

		public Campanha(string nome, string descricao, bool privado, bool ativo, string sistema, string cenario, int statusCampanhaId)
		{
			ValidateDomain(nome, descricao, privado, ativo, sistema, cenario, statusCampanhaId);
		}
		public Campanha(int id, string nome, string descricao, bool privado, bool ativo, string sistema, string cenario, int statusCampanhaId)
		{
			DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
			Id = id;
			ValidateDomain(nome, descricao, privado, ativo, sistema, cenario, statusCampanhaId);
		}

		public void Update(string nome, string descricao, bool privado, bool ativo, string sistema, string cenario, int statusCampanhaId)
		{
			ValidateDomain(nome, descricao, privado, ativo, sistema, cenario, statusCampanhaId);
			//ImagemId = imagemId;           
		}

		private void ValidateDomain(string nome, string descricao, bool privado, bool ativo, string sistema, string cenario, int statusCampanhaId)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
			DomainExceptionValidation.When(nome?.Length < 3, "short", "nome", "3");
			DomainExceptionValidation.When(nome?.Length > 50, "long", "nome", "50");
			DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "blank", "descricao", null);
			DomainExceptionValidation.When(descricao?.Length < 3, "short", "descricao", "3");
			DomainExceptionValidation.When(sistema?.Length < 3, "short", "sistema", "3");
			DomainExceptionValidation.When(cenario?.Length < 3, "short", "cenario", "3");

			Nome = nome;
			Descricao = descricao;
			Privado = privado;
			Ativo = ativo;
			Sistema = sistema;
			Cenario = cenario;
			StatusCampanhaId = statusCampanhaId;
		}

		public void CriarCampanha()
		{
			throw new NotImplementedException();
		}
		public void EditarCampanha()
		{
			throw new NotImplementedException();
		}
		public void AdicionarJogador(Usuario usuario)
		{
			throw new NotImplementedException();
		}
		public void RemoverJogador(Usuario usuario)
		{
			throw new NotImplementedException();
		}
		public void CriarSessao()
		{
			throw new NotImplementedException();
		}
		public void EncerrarCampanha()
		{
			throw new NotImplementedException();
		}
	}
}
