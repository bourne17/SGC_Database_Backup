using Microsoft.AspNetCore.Components;
using Radzen;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Connections;

namespace SGC_Database_Backup.Components.Pages.Connections
{
    public partial class ConnectionManager
    {
        [Inject]
        private IDatabaseOptionsRepository DatabaseOptionService { get; set; }

        [Inject]
        private DialogService DialogService { get; set; }

        private IEnumerable<DatabaseOptions> databaseOptions { get; set; }
        private bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadConnections();
        }

        private async Task LoadConnections()
        {
            try
            {
                isLoading = true;
                databaseOptions = await DatabaseOptionService.GetAllAsync();
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task EditConnection(int connectionId)
        {
            await DialogService.OpenAsync<AddEditConnection>("Editar conexión", new Dictionary<string, object?>
            {
                { "ConnectionId", connectionId },
                { "LoadConnections", EventCallback.Factory.Create(this, LoadConnections) }
            });
        }

        private async Task AddConnection()
        {
            await DialogService.OpenAsync<AddEditConnection>("Agregar conexión", new Dictionary<string, object?>
            {
                { "LoadConnections", EventCallback.Factory.Create(this, LoadConnections) }
            });
        }
    }
}
