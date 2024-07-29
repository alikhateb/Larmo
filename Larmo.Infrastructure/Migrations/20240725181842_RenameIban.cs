using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Larmo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameIban : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IBAN",
                table: "Operation",
                newName: "Iban");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Iban",
                table: "Operation",
                newName: "IBAN");
        }
    }
}
