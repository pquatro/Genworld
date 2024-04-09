using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
	public sealed class Genero : Entity
	{
		public string Nome { get; private set; }
		public bool Ativo { get; private set; }

		/// <summary>
		/// Atributos de relacionamento
		/// </summary>
		public ICollection<Campanha> Campanhas { get; set; }


		public Genero(string nome)
		{
			ValidateDomain(nome);
		}

		public Genero(int id, string nome, bool ativo)
		{
			DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
			Id = id;
			ValidateDomain(nome);
			Ativo = ativo;
		}

		public void Update(string nome, ICollection<Campanha> campanhas)
		{
			ValidateDomain(nome);
			Campanhas = campanhas;
		}

		private void ValidateDomain(string nome)
		{
			DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
			DomainExceptionValidation.When(nome?.Length < 3, "short", "nome", "3");
			DomainExceptionValidation.When(nome?.Length > 50, "long", "nome", "50");

			Nome = nome;
		}

		

	}
}
