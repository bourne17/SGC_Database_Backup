using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SGC_Database_Backup.Migrations
{
    /// <inheritdoc />
    public partial class CreateDestinationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DestinationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DestinationTypes",
                columns: new[] { "Id", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Local", null },
                    { 2, new DateTime(2026, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ftp", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationTypes");
        }
    }
}
