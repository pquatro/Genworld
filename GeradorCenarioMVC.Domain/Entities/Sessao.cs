using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
	public sealed class Sessao : Entity
	{
		public string Titulo { get; private set; }
		public string Descricao { get; private set; }
		public DateTime DataSessao { get; private set; }
		public double? Duracao { get; private set; }
		public bool? Online { get; private set; }
		public string Local { get; private set; }
		public string Vtt { get; private set; }
		public string YoutubeUrl { get; private set; }
		public double? Recompensa { get; private set; }



		/// <summary>
		/// Atributos de relacionamento
		/// </summary>
		public int GmId { get; set; }
		public Usuario Gm { get; set; }
		//public int? GrupoId { get; set; }
		//public Grupo Grupo { get; set; }
		public int CampanhaId { get; set; }
		public Campanha Campanha { get; set; }
		//public ICollection<Missao> Missoes { get; set; }
		public ICollection<Usuario> UsuariosPresentes { get; set; }



		public Sessao(string titulo, string descricao, DateTime dataSessao, double? duracao, bool? online, string local, string vtt, string youtubeUrl, double? recompensa)
		{
			ValidateDomain(titulo, descricao, dataSessao, duracao, online, local, vtt, youtubeUrl, recompensa);
			Recompensa = recompensa;
		}
		public Sessao(int id, string titulo, string descricao, DateTime dataSessao, double? duracao, bool? online, string local, string vtt, string youtubeUrl,double? recompensa)
		{
			DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
			Id = id;
			ValidateDomain(titulo, descricao, dataSessao, duracao, online, local, vtt, youtubeUrl, recompensa);
		}

		public void Update(string titulo, string descricao, DateTime dataSessao, double? duracao, bool? online, string local, string vtt, string youtubeUrl,
						   int gmId, int grupoId, int campanhaId, double? recompensa)
		{
			ValidateDomain(titulo, descricao, dataSessao, duracao, online, local, vtt, youtubeUrl, recompensa);
			GmId = gmId;
			//GrupoId = grupoId;
			CampanhaId = campanhaId;
		}

		private void ValidateDomain(string titulo, string descricao, DateTime dataSessao, double? duracao, bool? online, string local, string vtt, string youtubeUrl, double? recompensa)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "blank", "titulo", null);
			DomainExceptionValidation.When(titulo?.Length < 3, "short", "titulo", "3");
			DomainExceptionValidation.When(titulo?.Length > 50, "long", "titulo", "50");
			DomainExceptionValidation.When(descricao?.Length > 255, "long", "descricao", "255");
			DomainExceptionValidation.When(!int.TryParse(duracao.ToString(), out int n), "invalid_number", "duracaoHoras", null);
			DomainExceptionValidation.When(!DateTime.TryParse(dataSessao.ToString(), out DateTime m), "invalid_date", "data", null);
			DomainExceptionValidation.When(local?.Length < 3, "short", "local", "3");
			DomainExceptionValidation.When(vtt?.Length < 3, "short", "vtt", "3");
			DomainExceptionValidation.When(youtubeUrl?.Length < 3, "short", "youtubeUrl", "3");

			Titulo = titulo;
			Descricao = descricao;
			DataSessao = dataSessao;
			Duracao = duracao;
			Online = online;
			Local = local;
			Vtt = vtt;
			YoutubeUrl = youtubeUrl;
			Recompensa = recompensa;
		}


		

	}
}