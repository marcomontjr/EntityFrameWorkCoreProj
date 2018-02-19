using Alura.Filmes.App.Negocio;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Filmes.App.Extensions
{
    public static class ClassificacaoIndicativaExtensions
    {  
        public static string ParaString(this ClassificacaoIndicativa valor)
        {
            Dictionary<string, ClassificacaoIndicativa> map = SelecionaOpcao();

            return map.First(c => c.Value == valor).Key;
        }

        public static ClassificacaoIndicativa ParaValor(this string texto)
        {
            Dictionary<string, ClassificacaoIndicativa> map = SelecionaOpcao();

            if (map.Keys.Contains(texto))
                return map.First(c => c.Key.Equals(texto)).Value;
            else
                throw new System.Exception($"Valor Recebido: '{texto}',  Não Existe no Dicionário");                               
        }

        private static Dictionary<string, ClassificacaoIndicativa> SelecionaOpcao()
        {
            return new Dictionary<string, ClassificacaoIndicativa>
            {
                { "G", ClassificacaoIndicativa.Livre },
                { "PG", ClassificacaoIndicativa.MaioresQue10 },
                { "PG-13", ClassificacaoIndicativa.MaioresQue13 },
                { "R", ClassificacaoIndicativa.MaioresQue14 },
                { "NC-17", ClassificacaoIndicativa.MaioresUqe18 }
            };
        }       
    }
}