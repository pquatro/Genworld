using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorCenarioMVC.Domain.Entities
{
    public abstract class Personagem : Entity
    {
        public string NomePrimeiro { get; protected set; }
        public string NomeUltimo { get; protected set; }
        public string Apelido { get; protected set; }
        public string Caracteristicas { get; protected set; }

        public string Introducao { get; protected set; }

        public string Raca { get; protected set; }

        public string Tendencia { get; protected set; }
        public string Nascimento { get; protected set; }
        public string Genero { get; protected set; }
        public string Olhos { get; protected set; }
        public string Cabelo { get; protected set; }
        public string Pele { get; protected set; }
        public Double? Altura { get; protected set; }
        public Double? Peso { get; protected set; }
        public string NotasSecretas { get; protected set; }

        //public int GaleriaId { get; set; }
        //public Galeria Galeria { get; set; }
        //public int LocalizacaoId { get; set; }
        //public Mapa Localizacao { get; set; }
        //public ICollection<Conquista> Conquistas { get; set; }
        


        
    }
}
