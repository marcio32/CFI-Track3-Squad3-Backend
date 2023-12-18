using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFI_Track3_Squad3_Backend.Migrations
{
    public partial class ModelDBv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeletedTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_roles_RolId",
                        column: x => x.RolId,
                        principalTable: "roles",
                        principalColumn: "role_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Account_Id", "account_CreationDate", "account_IsBlocked", "account_Money", "account_UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 17, 20, 4, 45, 119, DateTimeKind.Local).AddTicks(3225), false, 1000.00m, 1 },
                    { 2, new DateTime(2023, 12, 17, 20, 4, 45, 119, DateTimeKind.Local).AddTicks(3250), false, 2000.00m, 1 },
                    { 3, new DateTime(2023, 12, 17, 20, 4, 45, 119, DateTimeKind.Local).AddTicks(3254), true, 1500.50m, 2 },
                    { 4, new DateTime(2023, 12, 17, 20, 4, 45, 119, DateTimeKind.Local).AddTicks(3255), false, 3000.75m, 2 }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "role_id", "role_deletedTimeUtc", "role_description", "role_isDeleted", "role_name" },
                values: new object[,]
                {
                    { 1, null, "Administrator", false, "Administrator" },
                    { 2, null, "Consultant", false, "Consultant" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedTimeUtc", "Email", "FirstName", "IsDelete", "LastName", "Password", "RolId" },
                values: new object[] { 1, null, "admin@gmail.com", "Admin", false, "Administrador", "eeec7cf230a0eb1c9e6be4aede189d43fdb5f86a6225cebef897fbb871b29d61", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedTimeUtc", "Email", "FirstName", "IsDelete", "LastName", "Password", "RolId" },
                values: new object[] { 2, null, "user@gmail.com", "User", false, "UserTest", "3260fa4b67859cffb492b7fe25752e910478832f0dcdf4e7891db1eb10f28f1f", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");
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
