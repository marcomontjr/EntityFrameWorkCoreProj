using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Alura.Filmes.App.Dados
{
    public class AtorConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
           builder
                .ToTable("actor");

           builder
                .Property(a => a.Id)
                .HasColumnName("actor_id");

           builder
                .Property(a => a.Nome)
                .HasColumnName("first_name")
                .HasColumnType("varchar(45)")
                .IsRequired();
        
           builder
                .Property(a => a.Sobrenome)
                .HasColumnName("last_name")
                .HasColumnType("varchar(45)")
                .IsRequired();

           builder
                .Property<DateTime>("last_update")
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            builder
                .HasIndex(a => a.Sobrenome)
                .HasName("idx_actor_last_name");

            builder
                .HasAlternateKey(a => new { a.Nome, a.Sobrenome });
        }
    }
}