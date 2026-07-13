using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net;
using System.Text.RegularExpressions;

namespace SGC_Database_Backup.Components.Dialogs
{
    public enum BrowseMode { Local, Ftp }

    public partial class FolderBrowser
    {
        [Parameter]
        public string CurrentPath { get; set; } = "";

        [Parameter]
        public BrowseMode Mode { get; set; } = BrowseMode.Local;

        [Parameter]
        public string FtpHost { get; set; } = "";

        [Parameter]
        public int FtpPort { get; set; } = 21;

        [Parameter]
        public string FtpUser { get; set; } = "";

        [Parameter]
        public string FtpPassword { get; set; } = "";

        [Inject]
        private DialogService DialogService { get; set; }

        private List<string> directories = [];
        private string currentPath = "";
        private bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            currentPath = string.IsNullOrEmpty(CurrentPath) ? (Mode == BrowseMode.Local ? @"C:\" : "/") : CurrentPath;
            await LoadDirectories();
        }

        private async Task LoadDirectories()
        {
            try
            {
                isLoading = true;
                directories = Mode == BrowseMode.Local
                    ? await LoadLocalDirectories()
                    : await LoadFtpDirectories();
            }
            catch (Exception ex)
            {
                directories = [];
                await DialogService.Alert($"Error al cargar directorios: {ex.Message}", "Error");
            }
            finally
            {
                isLoading = false;
            }
        }

        private Task<List<string>> LoadLocalDirectories()
        {
            var dirs = new List<string>();
            try
            {
                var di = new DirectoryInfo(currentPath);
                if (di.Exists)
                {
                    dirs.AddRange(di.GetDirectories().Select(d => d.Name));
                }
            }
            catch
            {
                // Ignorar directorios sin acceso
            }
            return Task.FromResult(dirs);
        }

        private async Task<List<string>> LoadFtpDirectories()
        {
            var dirs = new List<string>();
            try
            {
                var uri = $"ftp://{FtpHost}:{FtpPort}{currentPath}";
#pragma warning disable SYSLIB0014
                var request = (FtpWebRequest)WebRequest.Create(uri);
#pragma warning restore SYSLIB0014
                request.Credentials = new NetworkCredential(FtpUser, FtpPassword);
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;

                using var response = (FtpWebResponse)await request.GetResponseAsync();
                using var stream = response.GetResponseStream();
                using var reader = new StreamReader(stream);
                var lines = new List<string>();
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                        lines.Add(line);
                }

                foreach (var entry in lines)
                {
                    var name = ParseFtpDirectoryName(entry);
                    if (!string.IsNullOrEmpty(name) && IsFtpDirectory(entry))
                    {
                        dirs.Add(name);
                    }
                }
            }
            catch
            {
                // Ignorar errores de conexión FTP
            }
            return dirs;
        }

        private static bool IsFtpDirectory(string line)
        {
            if (line.StartsWith("d", StringComparison.OrdinalIgnoreCase))
                return true;
            if (line.Contains("<DIR>", StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private static string ParseFtpDirectoryName(string line)
        {
            if (line.StartsWith("d", StringComparison.OrdinalIgnoreCase) ||
                line.StartsWith("-", StringComparison.OrdinalIgnoreCase))
            {
                var match = Regex.Match(line, @"\S+\s+\d+\s+\S+\s+\S+\s+\d+\s+\w+\s+\d+\s+(\S.*)");
                if (match.Success)
                    return match.Groups[1].Value.Trim();
            }
            var dirMatch = Regex.Match(line, @"<DIR>\s+(.+)", RegexOptions.IgnoreCase);
            if (dirMatch.Success)
                return dirMatch.Groups[1].Value.Trim();

            if (!line.StartsWith("d", StringComparison.OrdinalIgnoreCase) &&
                !line.Contains("<DIR>", StringComparison.OrdinalIgnoreCase))
                return "";

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length > 0 ? parts[^1] : "";
        }

        private async void NavigateToPath()
        {
            await LoadDirectories();
        }

        private async Task NavigateToSubdirectory(string dir)
        {
            currentPath = Mode == BrowseMode.Local
                ? Path.Combine(currentPath, dir)
                : $"{currentPath.TrimEnd('/')}/{dir}";
            await LoadDirectories();
        }

        private async Task GoUp()
        {
            if (Mode == BrowseMode.Local)
            {
                var parent = Directory.GetParent(currentPath);
                currentPath = parent?.FullName ?? currentPath;
            }
            else
            {
                var trimmed = currentPath.TrimEnd('/');
                if (string.IsNullOrEmpty(trimmed) || trimmed == "/")
                    return;
                var lastSlash = trimmed.LastIndexOf('/');
                currentPath = lastSlash > 0 ? trimmed[..lastSlash] : "/";
            }
            await LoadDirectories();
        }

        private void SelectDirectory(string dir)
        {
            var fullPath = Mode == BrowseMode.Local
                ? Path.Combine(currentPath, dir)
                : $"{currentPath.TrimEnd('/')}/{dir}";
            DialogService.Close(fullPath);
        }

        private void SelectCurrentPath()
        {
            DialogService.Close(currentPath);
        }

        private void Close()
        {
            DialogService.Close(null);
        }
    }
}
