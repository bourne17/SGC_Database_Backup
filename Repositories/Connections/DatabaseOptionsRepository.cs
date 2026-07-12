using FirebirdSql.Data.FirebirdClient;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Generic;
using System.Data.Common;

namespace SGC_Database_Backup.Repositories.Connections
{
    public class DatabaseOptionsRepository(IDbContextFactory<ApplicationDbContext> context) : GenericRepository<DatabaseOptions>(context), IDatabaseOptionsRepository
    {
        public override async Task<IEnumerable<DatabaseOptions>> GetAllAsync()
        {
            var dbcontext = await context.CreateDbContextAsync();
            return await dbcontext.DatabaseOptions.Select(x => new DatabaseOptions
            {
                Id=x.Id,
                Description = x.Description,
                TypeEngineDescription = x.TypeEngine.Description,
                Host = x.Host,
                Port = x.Port,
                UserName = x.UserName,
                IsActive = x.IsActive
            }).ToListAsync();
        }

        public async Task<ConnectionTestResult> TestConnectionAsync(DatabaseOptions options)
        {
            if (options == null)
                return new ConnectionTestResult { Success = false, Message = "Opciones nulas." };

            try
            {
                using var connection =await  CreateConnection(options);
                // Intentamos abrir la conexión de forma asíncrona
                await connection.OpenAsync();
                // Si llegamos aquí, la conexión fue exitosa
                return new ConnectionTestResult
                {
                    Success = true,
                    Message = $"Conexión exitosa a {options.TypeEngineDescription} en {options.Host}:{options.Port}"
                };
            }
            catch (Exception ex)
            {
                return new ConnectionTestResult
                {
                    Success = false,
                    Message = $"Error al conectar: {ex.Message}",
                    Exception = ex
                };
            }
        }

        public async Task<DbConnection> CreateConnection(DatabaseOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));
            var dbcontext = await context.CreateDbContextAsync();
            var engine = await dbcontext.TypeEngines.Where(x => x.Id == options.TypeEngineId).FirstOrDefaultAsync();


            string connectionString = await BuildConnectionString(options,engine);

            

            return engine.Description.ToLower() switch
            {
                "mysql" => new MySqlConnection(connectionString),
                "mariadb" => new MySqlConnection(connectionString), // MySqlConnector soporta ambos
                "postgresql" => new NpgsqlConnection(connectionString),
                "sql server" => new SqlConnection(connectionString),
                "oracle" => new OracleConnection(connectionString),
                "sqlite" => new SqliteConnection(connectionString),
                "firebird" => new FbConnection(connectionString),
                _ => throw new NotSupportedException($"Motor '{options.TypeEngineDescription}' no es compatible.")
            };
        }

        private async Task<string> BuildConnectionString(DatabaseOptions options, TypeEngine engine)
        {
            // Normalizamos el motor para construir la cadena
            //string engine = options.TypeEngineDescription?.Trim().ToLowerInvariant();

            // Valores por defecto si faltan
            string host = options.Host ?? "localhost";
            int port = options.Port > 0 ? options.Port : engine?.DefaultPort ?? 0;
            string dbName = options.DefaultDB ?? (engine?.Description == "sqlite" ? "main.db" : "");
            string user = options.UserName ?? "";
            string password = options.Password ?? "";
            string sidService = options.Sid_Service ?? "";
            bool encrypt = options.IsEncrypt;
            bool trustCertificate = options.TrustServerCertificate;


            return engine?.Description.ToLower() switch
            {
                "mysql" or "mariadb" =>
                    $"Server={host};Port={port};Database={dbName};Uid={user};Pwd={password};",

                "postgresql" =>
                    $"Host={host};Port={port};Database={dbName};Username={user};Password={password};",

                "sql server" =>
                    $"Server={host},{port};Database={dbName};User Id={user};Password={password}; Encrypt={encrypt};TrustServerCertificate={trustCertificate};",

                "oracle" =>
                    // Usamos formato TNS simplificado (para Service Name)
                    $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={host})(PORT={port}))(CONNECT_DATA=(SERVICE_NAME={sidService})));User Id={user};Password={password};",

                "sqlite" =>
                    // Host se interpreta como la ruta del archivo
                    $"Data Source={host};Version=3;",

                "firebird" =>
                    $"Database={host};User={user};Password={password};DataSource={host};Port={port};",

                _ =>
                    throw new NotSupportedException($"No se puede construir cadena para '{engine?.Description}'")
            };
        }

        
    }
}
