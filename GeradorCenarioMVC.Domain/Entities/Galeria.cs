using GeradorCenarioMVC.Domain.Validation;
using System;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Galeria : Entity
    {
        public string Nome { get; private set; }
        
        

        public Galeria()
        {
            CreateGalleryName();
        }

        public Galeria(int id)
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            CreateGalleryName();
        }

        public void Update(ICollection<Imagem> imagens)
        {
            CreateGalleryName();
            Imagens = imagens;
        }

        private void CreateGalleryName()
        {
           string nome = DateTime.Now.ToString(); 
           Nome = nome;
            
        }

        
        public ICollection<Imagem> Imagens { get; set; }

        public ICollection<Cenario> Cenarios { get; set; }

        public ICollection<Pc> Pcs { get; set; }
        public ICollection<Npc> Npcs { get; set; }

        public ICollection<SecaoRodape> SecoesRodape { get; set; }

        //public int? PcId { get; set; }
        //public Pc Pc { get; set; }

        //public int? SecaoRodapeId { get; set; }
        //public SecaoRodape SecaoRodape { get; set; }

    }
}