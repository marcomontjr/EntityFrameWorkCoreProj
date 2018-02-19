using System.Collections.Generic;

namespace Alura.Filmes.App.Dados
{   
    public class Ator
    {
        public int Id { get; set; }        
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public IList<FilmeAtor> Filmografia { get; set; }

        public Ator()
        {
            Filmografia = new List<FilmeAtor>();
        }

        public override string ToString()
        {
            return Nome + " " + Sobrenome;
        }
    }
}