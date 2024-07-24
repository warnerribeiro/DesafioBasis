using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    internal class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("Ator");

            // Definindo nome da tabela
            builder.HasKey(a => a.ActorId);
            builder.Property(a => a.ActorId)
                .HasColumnName("AtorId").
                UseIdentityColumn()
                .HasComment("Chave primaria auto incremente");

            // Definindo campos
            builder.Property(a => a.Name)
                .HasColumnName("Nome")
                .IsUnicode(false)
                .IsRequired()
                .HasMaxLength(40)
                .HasComment("Nome do ator");


        }
    }
}
