using GeradorCenarioMVC.Domain.Validation;
using System.Diagnostics;

namespace GeradorCenarioMVC.Domain.Entities
{
    public sealed class Npc :Personagem
    {
        public bool? Visivel { get; private set; }


        
               

        public Npc(string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero,
                 string olhos, string cabelo, string pele, double? altura, double? peso, string notasSecretas, bool? visivel
                )
        {
            ValidateDomain(nomePrimeiro, nomeUltimo, apelido, caracteristicas, introducao, raca, tendencia, nascimento, genero,
                            olhos, cabelo, pele, altura, peso, notasSecretas, visivel);
        }

        public Npc(int id, string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero,
                  string olhos, string cabelo, string pele, double? altura, double? peso, string notasSecretas, bool? visivel
                 )
        {
            DomainExceptionValidation.When(id < 0, "invalid_number", "Id", null);
            Id = id;
            ValidateDomain(nomePrimeiro, nomeUltimo, apelido, caracteristicas, introducao, raca, tendencia, nascimento, genero,
                            olhos, cabelo, pele, altura, peso, notasSecretas, visivel);
        }

        public void Update(string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero,
                  string olhos, string cabelo, string pele, double? altura, double? peso, string notasSecretas, bool? visivel, int tipoNpcId, int fotoId,
                  ICollection<Conquista> conquistas, int localizacaoId, int galeriaId)
        {
            ValidateDomain(nomePrimeiro, nomeUltimo, apelido, caracteristicas, introducao, raca, tendencia, nascimento, genero,
                            olhos, cabelo, pele, altura, peso, notasSecretas, visivel);

            TipoNpcId = tipoNpcId;
            //FotoId = fotoId;
            Conquistas = conquistas;
            //LocalizacaoId = localizacaoId;
            //GaleriaId = galeriaId;

        }


        protected void ValidateDomain(string nomePrimeiro, string nomeUltimo, string apelido, string caracteristicas, string introducao, string raca, string tendencia, string nascimento, string genero,
                  string olhos, string cabelo, string pele, double? altura, double? peso, string notasSecretas, bool? visivel)
        {

            DomainExceptionValidation.When(string.IsNullOrEmpty(nomePrimeiro), "blank", "nomePrimeiro", null);
            DomainExceptionValidation.When(nomePrimeiro?.Length > 50, "long", "nomePrimeiro", "50");
            DomainExceptionValidation.When(nomePrimeiro.Any(Char.IsWhiteSpace), "whiteSpace", "nomePrimeiro", null);

            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeUltimo), "blank", "nomeUltimo", null);
            DomainExceptionValidation.When(nomeUltimo?.Length > 50, "long", "nomeUltimo", "50");
            DomainExceptionValidation.When(nomeUltimo.Any(Char.IsWhiteSpace), "whiteSpace", "nomeUltimo", null);

            DomainExceptionValidation.When(apelido?.Length > 50, "long", "apelido", "50");

            DomainExceptionValidation.When(caracteristicas?.Length > 255, "long", "caracteristicas", "255");

            DomainExceptionValidation.When(introducao?.Length > 255, "long", "introducao", "255");

            DomainExceptionValidation.When(raca?.Length > 50, "long", "raca", "50");

            DomainExceptionValidation.When(tendencia?.Length > 50, "long", "tendencia", "50");

            DomainExceptionValidation.When(olhos?.Length > 50, "long", "olhos", "50");

            DomainExceptionValidation.When(cabelo?.Length > 50, "long", "cabelo", "50");

            DomainExceptionValidation.When(pele?.Length > 50, "long", "pele", "50");
            
            DomainExceptionValidation.When(!double.TryParse(altura.ToString(), out double m), "invalid_number", "altura", null);

            DomainExceptionValidation.When(!double.TryParse(peso.ToString(), out double p), "invalid_number", "peso", null);
            
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
            Visivel = visivel;
        }

        public int TipoNpcId { get; set; }
        public TipoNpc TipoNpc { get; set; }

        //public int FotoId { get; set; }
        //public Imagem Foto { get; set; }        

        public ICollection<Campanha> Campanhas { get; set; }
        public ICollection<Grupo> Grupos { get; set; }

        public ICollection<Conquista> Conquistas { get; set; }

    }
}