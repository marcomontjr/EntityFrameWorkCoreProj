using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class PessoaConfiguration<T> : IEntityTypeConfiguration<T> where T : Pessoa
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
               .Property(f => f.Nome)
               .HasColumnName("first_name")
               .HasColumnType("varchar(45)")
               .IsRequired();

            builder
                .Property(f => f.Sobrenome)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

            builder
                .Property(f => f.Email)
                .HasColumnName("email")
                .HasColumnType("varchar(50)")
                .HasDefaultValueSql(null);

            builder
                .Property(f => f.Ativo)
                .HasColumnName("active")
                .HasColumnType("bit")
                .HasDefaultValueSql(1.ToString());

            builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");
        }
    }
}