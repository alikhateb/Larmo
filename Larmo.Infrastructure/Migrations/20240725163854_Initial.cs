using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Larmo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OperationType = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CurrencyType = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IBAN = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BeneficiaryName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BeneficiaryCountry = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BeneficiaryCity = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BeneficiaryArea = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BeneficiaryNearestMilestone = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    SourceOfFunds = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    SendingParty = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ReceivingParty = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientProfession = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientIdentityNumber = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientCountry = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientCity = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientArea = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    ClientNearestMilestone = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BeneficiaryClientRelationship = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    BeneficiaryActivity = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User.RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User.RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User.RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User.RefreshTokens_UserId",
                table: "User.RefreshTokens",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "User.RefreshTokens");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
