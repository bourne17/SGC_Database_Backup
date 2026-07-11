using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGC_Database_Backup.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTypeEngineOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 1,
                column: "DefaultPort",
                value: 3306);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 2,
                column: "DefaultPort",
                value: 3306);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 3,
                column: "DefaultPort",
                value: 1521);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 4,
                column: "DefaultPort",
                value: 5432);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 1433, true });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 7,
                column: "DefaultPort",
                value: 3050);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 1,
                column: "DefaultPort",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 2,
                column: "DefaultPort",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 3,
                column: "DefaultPort",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 4,
                column: "DefaultPort",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DefaultPort", "HasSqlOptions" },
                values: new object[] { 0, false });

            migrationBuilder.UpdateData(
                table: "TypeEngine",
                keyColumn: "Id",
                keyValue: 7,
                column: "DefaultPort",
                value: 0);
        }
    }
}
