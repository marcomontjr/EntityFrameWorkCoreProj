using System.Collections.Generic;

namespace Alura.Filmes.App.Dados
{
    public class Categoria
    {
        public byte Id { get; set; }
        public string Nome { get; set; }
        public IList<FilmeCategoria> Filmes { get; set; }

        public Categoria()
        {
            Filmes = new List<FilmeCategoria>();
        }
    }
}