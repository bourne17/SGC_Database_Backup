using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGC_Database_Backup.Migrations
{
    /// <inheritdoc />
    public partial class AlterTypeEngines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackupsJobs_DatabaseConnections_DbConnectionId",
                table: "BackupsJobs");

            migrationBuilder.DropTable(
                name: "DatabaseConnections");

            migrationBuilder.AddColumn<int>(
                name: "DefaultPort",
                table: "TypeEngine",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasSqlOptions",
                table: "TypeEngine",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DatabaseOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeEngineId = table.Column<int>(type: "INTEGER", nullable: true),
                    Host = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Sid_Service = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DefaultDB = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEncrypt = table.Column<bool>(type: "INTEGER", nullable: false),
                    TrustServerCertificate = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseOptions_TypeEngine_TypeEngineId",
                        column: x => x.TypeEngineId,
                        principalTable: "TypeEngine",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseOptions_TypeEngineId",
                table: "DatabaseOptions",
                column: "TypeEngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackupsJobs_DatabaseOptions_DbConnectionId",
                table: "BackupsJobs",
                column: "DbConnectionId",
                principalTable: "DatabaseOptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackupsJobs_DatabaseOptions_DbConnectionId",
                table: "BackupsJobs");

            migrationBuilder.DropTable(
                name: "DatabaseOptions");

            migrationBuilder.DropColumn(
                name: "DefaultPort",
                table: "TypeEngine");

            migrationBuilder.DropColumn(
                name: "HasSqlOptions",
                table: "TypeEngine");

            migrationBuilder.CreateTable(
                name: "DatabaseConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TypeEngineId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DefaultDB = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Host = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEncrypt = table.Column<bool>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    Sid_Service = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TrustServerCertificate = table.Column<bool>(type: "INTEGER", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseConnections_TypeEngine_TypeEngineId",
                        column: x => x.TypeEngineId,
                        principalTable: "TypeEngine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseConnections_TypeEngineId",
                table: "DatabaseConnections",
                column: "TypeEngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_BackupsJobs_DatabaseConnections_DbConnectionId",
                table: "BackupsJobs",
                column: "DbConnectionId",
                principalTable: "DatabaseConnections",
                principalColumn: "Id");
        }
    }
}
