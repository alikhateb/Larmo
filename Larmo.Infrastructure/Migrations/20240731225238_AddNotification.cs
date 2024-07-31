using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Larmo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNotification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    MotherName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Gender = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Profession = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Employer = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    StartWorkDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdentityNumber = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    IdentityIssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdentityExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsLibyanNationality = table.Column<bool>(type: "boolean", nullable: false),
                    Nationality = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Resident = table.Column<bool>(type: "boolean", nullable: false),
                    PassportNumber = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    PassportNumberIssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PassportNumberExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    City = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Area = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Street = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    NearestMilestone = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    IsChecked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");
        }
    }
}
