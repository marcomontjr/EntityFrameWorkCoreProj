using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder
             .ToTable("staff");

            builder
                .Property(f => f.Id)
                .HasColumnName("staff_id")
                .HasColumnType("tinyint");           

            builder
                .Property(f => f.NomeUsuario)
                .HasColumnName("username")
                .HasColumnType("varchar(16)")
                .IsRequired();

            builder
                .Property(f => f.Senha)
                .HasColumnName("password")
                .HasColumnType("varchar(40)")
                .HasDefaultValueSql(null);

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}