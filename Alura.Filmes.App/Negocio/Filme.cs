using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using System.Collections.Generic;

namespace Alura.Filmes.App.Dados
{
    public class Filme
    { 
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string AnoLancamento { get; set; }     
        public short Duracao { get; set; }
        public string TextoClassificacao { get; private set; }
        public ClassificacaoIndicativa Classificacao
        {
            get { return TextoClassificacao.ParaValor(); }
            set { TextoClassificacao = value.ParaString(); }
        }
        public IList<FilmeAtor> Atores { get; set; }
        public IList<FilmeCategoria> Categorias { get; set; }
        public Idioma IdiomaFalado { get; set; }
        public Idioma IdiomaOriginal { get; set; }

        public Filme()
        {
            Atores = new List<FilmeAtor>();
            Categorias = new List<FilmeCategoria>();
        }    

        public override string ToString()
        {
            return "Titulo: " + Titulo + "\n"
                    + "Descricao: " + Descricao;
        }
    }
}