using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGC_Database_Backup.Migrations
{
    /// <inheritdoc />
    public partial class CreateSystemTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DatabaseConnections",
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
                    table.PrimaryKey("PK_DatabaseConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseConnections_TypeEngine_TypeEngineId",
                        column: x => x.TypeEngineId,
                        principalTable: "TypeEngine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DestinationTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Path = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    Host = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    Bucket = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Destination_DestinationTypes_DestinationTypeId",
                        column: x => x.DestinationTypeId,
                        principalTable: "DestinationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmailConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SmtpServer = table.Column<string>(type: "TEXT", nullable: false),
                    SmtpPort = table.Column<int>(type: "INTEGER", nullable: false),
                    SmtpUser = table.Column<string>(type: "TEXT", nullable: false),
                    SmtpPassword = table.Column<string>(type: "TEXT", nullable: false),
                    FromEmail = table.Column<string>(type: "TEXT", nullable: false),
                    IsTLS = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BackupsJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DbConnectionId = table.Column<int>(type: "INTEGER", nullable: true),
                    DatabaseList = table.Column<string>(type: "TEXT", nullable: false),
                    ObjectToBackup = table.Column<string>(type: "TEXT", nullable: false),
                    BackupPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    DestinationId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsCompress = table.Column<bool>(type: "INTEGER", nullable: false),
                    RetentionDays = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackupsJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackupsJobs_DatabaseConnections_DbConnectionId",
                        column: x => x.DbConnectionId,
                        principalTable: "DatabaseConnections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BackupsJobs_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BackupsLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BackupsJobId = table.Column<int>(type: "INTEGER", nullable: true),
                    BackuptJobId = table.Column<int>(type: "INTEGER", nullable: true),
                    BackupJobName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    FileSizeMb = table.Column<decimal>(type: "decimal(19,2)", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    ErrorMessage = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackupsLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackupsLogs_BackupJobStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BackupJobStatus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BackupsLogs_BackupLogsTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "BackupLogsTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BackupsLogs_BackupsJobs_BackupsJobId",
                        column: x => x.BackupsJobId,
                        principalTable: "BackupsJobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BackupsLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NotificationRules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BackupsJobsId = table.Column<int>(type: "INTEGER", nullable: true),
                    OnSuccess = table.Column<bool>(type: "INTEGER", nullable: false),
                    OnFailure = table.Column<bool>(type: "INTEGER", nullable: false),
                    Recipients = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationRules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationRules_BackupsJobs_BackupsJobsId",
                        column: x => x.BackupsJobsId,
                        principalTable: "BackupsJobs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BackupsJobsId = table.Column<int>(type: "INTEGER", nullable: true),
                    FrecuencyId = table.Column<int>(type: "INTEGER", nullable: true),
                    StartAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DayOfMonth = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    RunBetweenStart = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    RunBetweenEnd = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    IsRunMissed = table.Column<bool>(type: "INTEGER", nullable: false),
                    NextRun = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastRun = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_BackupsJobs_BackupsJobsId",
                        column: x => x.BackupsJobsId,
                        principalTable: "BackupsJobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Schedules_ScheduleFrecuency_FrecuencyId",
                        column: x => x.FrecuencyId,
                        principalTable: "ScheduleFrecuency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackupsJobs_DbConnectionId",
                table: "BackupsJobs",
                column: "DbConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BackupsJobs_DestinationId",
                table: "BackupsJobs",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_BackupsLogs_BackupsJobId",
                table: "BackupsLogs",
                column: "BackupsJobId");

            migrationBuilder.CreateIndex(
                name: "IX_BackupsLogs_StatusId",
                table: "BackupsLogs",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BackupsLogs_TypeId",
                table: "BackupsLogs",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BackupsLogs_UserId",
                table: "BackupsLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseConnections_TypeEngineId",
                table: "DatabaseConnections",
                column: "TypeEngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Destination_DestinationTypeId",
                table: "Destination",
                column: "DestinationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationRules_BackupsJobsId",
                table: "NotificationRules",
                column: "BackupsJobsId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_BackupsJobsId",
                table: "Schedules",
                column: "BackupsJobsId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_FrecuencyId",
                table: "Schedules",
                column: "FrecuencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackupsLogs");

            migrationBuilder.DropTable(
                name: "EmailConfigurations");

            migrationBuilder.DropTable(
                name: "NotificationRules");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "BackupsJobs");

            migrationBuilder.DropTable(
                name: "DatabaseConnections");

            migrationBuilder.DropTable(
                name: "Destination");
        }
    }
}
