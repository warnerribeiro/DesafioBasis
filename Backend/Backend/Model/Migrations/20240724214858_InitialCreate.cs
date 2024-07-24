using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "int", nullable: false, comment: "Chave primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false, comment: "Descrição do assunto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.SubjectId);
                });

            migrationBuilder.CreateTable(
                name: "Ator",
                columns: table => new
                {
                    AtorId = table.Column<int>(type: "int", nullable: false, comment: "Chave primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Nome do ator")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ator", x => x.AtorId);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    LicroId = table.Column<int>(type: "int", nullable: false, comment: "Chave primaria auto incremente")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Titulo do Livro"),
                    Editora = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false, comment: "Editora do Livro"),
                    Edicao = table.Column<int>(type: "int", unicode: false, nullable: false, comment: "Edição do Livro"),
                    AnoPublicacao = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false, comment: "Ano de Publicação do Livro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.LicroId);
                });

            migrationBuilder.CreateTable(
                name: "LivroAssunto",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAssunto", x => new { x.BookId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Assunto_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Assunto",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAssunto_Livro_BookId",
                        column: x => x.BookId,
                        principalTable: "Livro",
                        principalColumn: "LicroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroAtor",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroAtor", x => new { x.BookId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_LivroAtor_Ator_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Ator",
                        principalColumn: "AtorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroAtor_Livro_BookId",
                        column: x => x.BookId,
                        principalTable: "Livro",
                        principalColumn: "LicroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_BookId",
                table: "LivroAssunto",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAssunto_SubjectId",
                table: "LivroAssunto",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAtor_ActorId",
                table: "LivroAtor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroAtor_BookId",
                table: "LivroAtor",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LivroAssunto");

            migrationBuilder.DropTable(
                name: "LivroAtor");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Ator");

            migrationBuilder.DropTable(
                name: "Livro");
        }
    }
}
