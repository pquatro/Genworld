﻿using GeradorCenarioMVC.Domain.Validation;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class TipoConquista : Entity
    {
        public string Nome { get; private set; }
        public bool? Ativo { get; private set; }
        

        public TipoConquista(string nome, bool? ativo)
        {
            ValidateDomain(nome);
            Ativo = ativo;
        }
        public TipoConquista(int id, string nome, bool? ativo)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            Ativo = ativo;
            ValidateDomain(nome);
        }

        public void Update(string nome)
        {
            ValidateDomain(nome);
        }

        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
            DomainExceptionValidation.When(nome?.Length < 3, "short", "nome", "3");
            DomainExceptionValidation.When(nome?.Length > 50, "long", "nome", "50");

            Nome = nome;
        }

        public ICollection<Conquista> Conquistas { get; set; }
    }
}