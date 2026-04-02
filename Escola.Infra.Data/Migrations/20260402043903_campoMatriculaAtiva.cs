using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class campoMatriculaAtiva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Matricula",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Matricula");
        }
    }
}
