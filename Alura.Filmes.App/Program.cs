using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();
                StoredProcedure(contexto);

                var sql = "INSERT INTO language (name) VALUES ('Teste 1'), ('Teste 2'), ('Teste 3')";
                var registros = contexto.Database.ExecuteSqlCommand(sql);
                Console.WriteLine("Total de Registros Afetdados: " + registros);

                var deleteSql = "DELETE FROM language WHERE name LIKE 'Teste%'";
                var registrosDel = contexto.Database.ExecuteSqlCommand(deleteSql);
                Console.WriteLine("Total de Registros Afetdados: " + registrosDel);
            }
            Console.ReadKey();
        }

        private static void StoredProcedure(AluraFilmesContexto contexto)
        {
            var categ = "Action"; // 36    
            var paramCateg = new SqlParameter("category_name", categ);
            var paramTotal = new SqlParameter
            {
                ParameterName = "@total_actors",
                Size = 4,
                Direction = System.Data.ParameterDirection.Output
            };

            contexto.Database
                .ExecuteSqlCommand("execute total_actors_from_given_category @category_name, @total_actors OUT",
                                    paramCateg, paramTotal);

            Console.WriteLine($"O Total de atores na categoria {categ} é de {paramTotal.Value}.");
        }
    }
}