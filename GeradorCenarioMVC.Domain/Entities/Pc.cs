using GeradorCenarioMVC.Domain.Validation;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Pc : Personagem
    {
        public int? Idade { get; private set; }      
        public string Journal { get; private set; }        
        public string Frase { get; private set; }        
        public string Historia { get; private set; }
        
                
        public Pc(string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero, 
                  string olhos, string cabelo,  string pele, double? altura, double? peso, string notasSecretas, int? idade, string journal, string frase, string historia
                 )
        {
            ValidateDomain(nomePrimeiro, nomeUltimo, apelido, caracteristicas, introducao, raca, tendencia, nascimento, genero,
                            olhos, cabelo, pele, altura, peso, notasSecretas, idade, journal, frase, historia);
        }

        public Pc(int id, string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero,
                  string olhos, string cabelo, string pele, double? altura, double? peso, string notasSecretas, int? idade, string journal, string frase, string historia
                 )
        {            
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nomePrimeiro, nomeUltimo, apelido, caracteristicas, introducao, raca, tendencia, nascimento, genero,
                            olhos, cabelo, pele, altura, peso, notasSecretas, idade, journal, frase, historia);
        }

        public void Update(string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero,
                  string olhos, string cabelo, string pele, double? altura, double? peso, string notasSecretas, int? idade, string journal, string frase, string historia, int jogadorId, 
                  ICollection<Conquista> conquistas, int localizacaoId, int galeriaId)
        {
            ValidateDomain(nomePrimeiro, nomeUltimo, apelido, caracteristicas, introducao, raca, tendencia, nascimento, genero,
                            olhos, cabelo, pele, altura, peso, notasSecretas, idade, journal, frase, historia);

            JogadorId = jogadorId;
            Conquistas = conquistas;
            //LocalizacaoId = localizacaoId;
            //GaleriaId = galeriaId;

        }


        protected void ValidateDomain(string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero,
                  string olhos, string cabelo, string pele, double? altura, double? peso, string notasSecretas, int? idade, string journal, string frase, string historia)
        {
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomePrimeiro), "blank", "nomePrimeiro",null);
            DomainExceptionValidation.When(nomePrimeiro.Any(Char.IsWhiteSpace), "whiteSpace", "nomePrimeiro", null);            
            DomainExceptionValidation.When(nomePrimeiro?.Length>50, "long", "nomePrimeiro", "50");
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeUltimo), "blank", "nomeUltimo", null);            
            DomainExceptionValidation.When(nomeUltimo.Any(Char.IsWhiteSpace), "whiteSpace", "nomeUltimo", null);
            DomainExceptionValidation.When(nomeUltimo?.Length > 50, "long", "nomeUltimo", "50");

            DomainExceptionValidation.When(apelido?.Length > 50, "long", "apelido", "50");

            DomainExceptionValidation.When(caracteristicas?.Length > 255, "long", "caracteristicas", "255");

            DomainExceptionValidation.When(introducao?.Length > 255, "long", "introducao", "255");            

            DomainExceptionValidation.When(raca?.Length > 50, "long", "raca", "50");

            DomainExceptionValidation.When(tendencia?.Length > 50, "long", "tendencia", "50");            

            DomainExceptionValidation.When(olhos?.Length > 50, "long", "olhos", "50");

            DomainExceptionValidation.When(cabelo?.Length > 50, "long", "cabelo", "50");

            DomainExceptionValidation.When(pele?.Length > 50, "long", "pele", "50");

            DomainExceptionValidation.When(!int.TryParse(idade.ToString(), out int n), "invalid_number", "idade", null);

            DomainExceptionValidation.When(!double.TryParse(altura.ToString(), out double m), "invalid_number", "altura", null);

            DomainExceptionValidation.When(!double.TryParse(peso.ToString(), out double p), "invalid_number", "peso", null);

            DomainExceptionValidation.When(frase?.Length > 255, "long", "frase", "255");
            


            NomePrimeiro = nomePrimeiro;
            NomeUltimo = nomeUltimo;
            Apelido = apelido;
            Caracteristicas = caracteristicas;
            Introducao = introducao;
            Raca = raca; 
            Tendencia = tendencia; 
            Nascimento = nascimento;
            Genero = genero;
            Olhos = olhos;
            Cabelo = cabelo;
            Pele = pele;
            Altura = altura;
            Peso = peso;
            NotasSecretas = notasSecretas;
            Idade = idade;
            Journal = journal;
            Frase = frase;
            Historia = historia;
        }

        
        public int JogadorId { get; set; }
        public Usuario Jogador { get; set; }
        public int? GaleriaId { get; set; }
        public Galeria Galeria { get; set; }
        public int? ImagemId { get; set; }
        public Imagem Imagem { get; set; }
        public ICollection<Enredo> Enredos { get; set; }
        public ICollection<Campanha> Campanhas { get; set; }
        public ICollection<Conquista> Conquistas { get; set; }
        public ICollection<Grupo> Grupos { get; set; }
    }
}