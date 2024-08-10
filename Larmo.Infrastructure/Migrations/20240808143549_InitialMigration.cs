using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Larmo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Date = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    OperationType = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CurrencyType = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Iban = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
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
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DependOn = table.Column<string>(type: "text", nullable: true),
                    ModuleName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
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
                name: "GroupRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<string>(type: "text", nullable: true),
                    RoleId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupRole_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GroupRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "User.RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true),
                    ExpireOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UserGroup",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    GroupId = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroup_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupRole_GroupId",
                table: "GroupRole",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRole_RoleId",
                table: "GroupRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User.RefreshTokens_UserId",
                table: "User.RefreshTokens",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                table: "UserGroup",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_UserId",
                table: "UserGroup",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupRole");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "User.RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserGroup");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
