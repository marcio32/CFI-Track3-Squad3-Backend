using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CFI_Track3_Squad3_Backend.Migrations
{
    public partial class TestDBV12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    account_CreationDate = table.Column<string>(type: "VARCHAR(100)", nullable: true),
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
                    { 1, "2023-12-14T19:22:44.2373951", false, 1000.00m, 1 },
                    { 2, "2023-12-14T19:22:44.2373951", false, 2000.00m, 1 },
                    { 3, "2023-12-14T19:22:44.2373951", true, 1500.50m, 2 },
                    { 4, "2023-12-14T19:22:44.2373951", false, 3000.75m, 2 }
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
                values: new object[] { 1, null, "adm@gmail.com", "Pablo", false, "Ortiz", "9f3d321cd0a1ccafa899226d5190f74618cb23b789aa998e1d7f741956132434", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DeletedTimeUtc", "Email", "FirstName", "IsDelete", "LastName", "Password", "RolId" },
                values: new object[] { 2, null, "noadm@gmail.com", "Kevin", false, "Johnson", "a10ad3a74bccd29b56cb5ec5a213d1a27b293b6bb88797418a31f09c2a707bf4", 2 });

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
