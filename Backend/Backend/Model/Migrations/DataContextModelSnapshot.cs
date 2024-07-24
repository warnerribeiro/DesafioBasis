﻿// <auto-generated />
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AtorId")
                        .HasComment("Chave primaria auto incremente");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .IsUnicode(false)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("Nome")
                        .HasComment("Nome do ator");

                    b.HasKey("ActorId");

                    b.ToTable("Ator", (string)null);
                });

            modelBuilder.Entity("Domain.Model.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("LicroId")
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

            modelBuilder.Entity("Domain.Model.BookActor", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "ActorId");

                    b.HasIndex("ActorId");

                    b.HasIndex("BookId");

                    b.ToTable("LivroAtor", (string)null);
                });

            modelBuilder.Entity("Domain.Model.BookSubject", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "SubjectId");

                    b.HasIndex("BookId");

                    b.HasIndex("SubjectId");

                    b.ToTable("LivroAssunto", (string)null);
                });

            modelBuilder.Entity("Domain.Model.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
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

            modelBuilder.Entity("Domain.Model.BookActor", b =>
                {
                    b.HasOne("Domain.Model.Actor", "Actor")
                        .WithMany("BookActor")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Model.Book", "Book")
                        .WithMany("BookActor")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

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

            modelBuilder.Entity("Domain.Model.Actor", b =>
                {
                    b.Navigation("BookActor");
                });

            modelBuilder.Entity("Domain.Model.Book", b =>
                {
                    b.Navigation("BookActor");

                    b.Navigation("BookSubject");
                });

            modelBuilder.Entity("Domain.Model.Subject", b =>
                {
                    b.Navigation("BookSubject");
                });
#pragma warning restore 612, 618
        }
    }
}
