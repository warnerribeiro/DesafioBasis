﻿// <auto-generated />
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240725132713_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AutorId")
                        .HasComment("Chave primaria auto incremente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Nome")
                        .HasComment("Nome do ator");

                    b.HasKey("AuthorId");

                    b.ToTable("Autor", (string)null);
                });

            modelBuilder.Entity("Domain.Model.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LivroId")
                        .HasComment("Chave primaria auto incremente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("Edition")
                        .IsUnicode(false)
                        .HasColumnType("int")
                        .HasColumnName("Edicao")
                        .HasComment("Edição do Livro");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Editora")
                        .HasComment("Editora do Livro");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Titulo")
                        .HasComment("Titulo do Livro");

                    b.Property<string>("YearOfPublication")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)")
                        .HasColumnName("AnoPublicacao")
                        .HasComment("Ano de Publicação do Livro");

                    b.HasKey("BookId");

                    b.ToTable("Livro", (string)null);
                });

            modelBuilder.Entity("Domain.Model.BookAuthor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("LivroId");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("AutorId");

                    b.HasKey("BookId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("LivroAutor", (string)null);
                });

            modelBuilder.Entity("Domain.Model.BookSubject", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("LivroId");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("AssuntoId");

                    b.HasKey("BookId", "SubjectId");

                    b.HasIndex("BookId");

                    b.HasIndex("SubjectId");

                    b.ToTable("LivroAssunto", (string)null);
                });

            modelBuilder.Entity("Domain.Model.BookValue", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("LivroId");

                    b.Property<int>("OriginPurchaseId")
                        .HasColumnType("int")
                        .HasColumnName("OrigemCompraId");

                    b.Property<decimal>("Value")
                        .HasColumnType("money")
                        .HasColumnName("Valor");

                    b.HasKey("BookId", "OriginPurchaseId");

                    b.HasIndex("BookId");

                    b.HasIndex("OriginPurchaseId");

                    b.ToTable("LivroValor", (string)null);
                });

            modelBuilder.Entity("Domain.Model.OriginPurchase", b =>
                {
                    b.Property<int>("OriginPurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("OrigemCompraId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OriginPurchaseId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)")
                        .HasColumnName("Nome")
                        .HasComment("Nome de origem da compra");

                    b.HasKey("OriginPurchaseId");

                    b.ToTable("OrigemCompra", (string)null);

                    b.HasData(
                        new
                        {
                            OriginPurchaseId = 1,
                            Name = "Balcão"
                        },
                        new
                        {
                            OriginPurchaseId = 2,
                            Name = "Banca"
                        },
                        new
                        {
                            OriginPurchaseId = 3,
                            Name = "Evento"
                        },
                        new
                        {
                            OriginPurchaseId = 4,
                            Name = "Internet"
                        },
                        new
                        {
                            OriginPurchaseId = 5,
                            Name = "Self-Service"
                        });
                });

            modelBuilder.Entity("Domain.Model.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AssuntoId")
                        .HasComment("Chave primaria auto incremente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Descricao")
                        .HasComment("Descrição do assunto");

                    b.HasKey("SubjectId");

                    b.ToTable("Assunto", (string)null);
                });

            modelBuilder.Entity("Domain.Model.BookAuthor", b =>
                {
                    b.HasOne("Domain.Model.Author", "Author")
                        .WithMany("BookAuthor")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Book", "Book")
                        .WithMany("BookAuthor")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Domain.Model.BookSubject", b =>
                {
                    b.HasOne("Domain.Model.Book", "Book")
                        .WithMany("BookSubject")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Subject", "Subject")
                        .WithMany("BookSubject")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Domain.Model.BookValue", b =>
                {
                    b.HasOne("Domain.Model.Book", "Book")
                        .WithMany("BookValue")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.OriginPurchase", "OriginPurchase")
                        .WithMany("BookValue")
                        .HasForeignKey("OriginPurchaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("OriginPurchase");
                });

            modelBuilder.Entity("Domain.Model.Author", b =>
                {
                    b.Navigation("BookAuthor");
                });

            modelBuilder.Entity("Domain.Model.Book", b =>
                {
                    b.Navigation("BookAuthor");

                    b.Navigation("BookSubject");

                    b.Navigation("BookValue");
                });

            modelBuilder.Entity("Domain.Model.OriginPurchase", b =>
                {
                    b.Navigation("BookValue");
                });

            modelBuilder.Entity("Domain.Model.Subject", b =>
                {
                    b.Navigation("BookSubject");
                });
#pragma warning restore 612, 618
        }
    }
}
