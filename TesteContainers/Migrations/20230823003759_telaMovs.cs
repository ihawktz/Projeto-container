using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteContainers.Migrations
{
    /// <inheritdoc />
    public partial class telaMovs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMovs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dtFim = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");
        }
    }
}
