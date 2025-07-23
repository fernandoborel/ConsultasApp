using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultasApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEspecialidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Especialidade",
                table: "Medicos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Especialidade",
                table: "Medicos");
        }
    }
}
