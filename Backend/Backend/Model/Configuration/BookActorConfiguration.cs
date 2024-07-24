using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Model.Configuration
{
    internal class BookActorConfiguration : IEntityTypeConfiguration<BookActor>
    {
        public void Configure(EntityTypeBuilder<BookActor> builder)
        {
            // Definindo nome da tabela
            builder.ToTable("LivroAtor");

            // Definindo chave primaria
            builder.HasKey(a => new { a.BookId, a.ActorId });

            // Definindo index
            builder.HasIndex(a => a.BookId);
            builder.HasIndex(b => b.ActorId);

            // Definindo relacionamento
            builder.HasOne(a => a.Actor)
                .WithMany(a => a.BookActor)
                .HasForeignKey(a => a.ActorId);

            builder.HasOne(a => a.Book)
                .WithMany(a => a.BookActor)
                .HasForeignKey(a => a.BookId);
        }
    }
}
