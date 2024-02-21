using GeradorCenarioMVC.Domain.Validation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Campanha : Entity
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public string Introducao { get; private set; }
        public bool? Ativo { get; private set; }        


        public Campanha(string nome, string descricao, string introducao, bool? ativo)
        {
            ValidateDomain(nome, descricao, introducao, ativo);
        }
        public Campanha(int id, string nome, string descricao, string introducao, bool? ativo)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nome, descricao, introducao, ativo);
        }

        public void Update(string nome, string descricao, string introducao, int imagemId, bool? ativo)
        {
            ValidateDomain(nome, descricao, introducao, ativo);
            //ImagemId = imagemId;           
        }        

        private void ValidateDomain(string nome, string descricao, string introducao, bool? ativo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "blank", "nome", null);
            DomainExceptionValidation.When(nome?.Length<3, "short", "nome", "3");
            DomainExceptionValidation.When(nome?.Length > 50, "long", "nome", "50");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "blank", "descricao", null);
            DomainExceptionValidation.When(descricao?.Length < 3, "short", "descricao", "3");            
                        
            Nome = nome;
            Descricao = descricao;
            Introducao = introducao;           
            Ativo = ativo;            
        }

        public void ConvidarJogadores(string email)
        {
            throw new NotImplementedException();
        }



        public int? ImagemId { get; set; }
        public Imagem Imagem { get; set; }
        public int CenarioId { get; set; }
        public Cenario Cenario { get; set; }
        public ICollection<Pc> Pcs { get; set; }
        public ICollection<Npc> Npcs { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
        //public ICollection<Sessao> Sessoes { get; set; }
        //public ICollection<Enredo> Enredos { get; set; }
    }
}
