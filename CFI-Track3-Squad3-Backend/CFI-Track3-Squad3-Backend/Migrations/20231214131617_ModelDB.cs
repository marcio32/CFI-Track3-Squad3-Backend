using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFI_Track3_Squad3_Backend.Migrations
{
    public partial class ModelDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_CreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    account_Money = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    account_IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    account_UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account_Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role_isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    role_deletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Points = table.Column<int>(type: "NUMBER", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.RolId);
                    table.ForeignKey(
                        name: "FK_Users_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "role_id");
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Account_Id", "account_CreationDate", "account_IsBlocked", "account_Money", "account_UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 14, 10, 16, 17, 105, DateTimeKind.Local).AddTicks(2131), false, 1000.00m, 1 },
                    { 2, new DateTime(2023, 12, 14, 10, 16, 17, 105, DateTimeKind.Local).AddTicks(2151), false, 2000.00m, 1 },
                    { 3, new DateTime(2023, 12, 14, 10, 16, 17, 105, DateTimeKind.Local).AddTicks(2153), true, 1500.50m, 2 },
                    { 4, new DateTime(2023, 12, 14, 10, 16, 17, 105, DateTimeKind.Local).AddTicks(2155), false, 3000.75m, 2 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "role_id", "role_deletedTimeUtc", "role_description", "role_isDeleted", "role_name" },
                values: new object[,]
                {
                    { 1, null, "Administrator", false, "Administrator" },
                    { 2, null, "Consultant", false, "Consultant" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
