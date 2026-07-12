using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Radzen;
using SGC_Database_Backup.Components.Extensions;
using SGC_Database_Backup.Data;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Connections;

namespace SGC_Database_Backup.Components.Pages.Connections
{
    public partial class AddEditConnection
    {
        [Parameter]
        public int? ConnectionId { get; set; }

        [Parameter]
        public EventCallback LoadConnections { get; set; }

        [Inject]
        private IDatabaseOptionsRepository DatabaseOptionService { get; set; }

        [Inject]
        private ITypeEngineRepository TypeEngineService { get; set; }

        [Inject]
        private NotificationService NotificationService { get; set; }

        [Inject]
        private DialogService DialogService { get; set; }

        private DatabaseOptions? connectionToEdit = new();
        private IEnumerable<TypeEngine> typeEngines = [];

        private bool isLoading = false;
        private bool isSaving = false;
        private bool hasSqlOptions = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;
                await LoadTypeEngines();
                connectionToEdit = ConnectionId.HasValue
                    ? await DatabaseOptionService.FindAsync(ConnectionId.Value)
                    : new DatabaseOptions();
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task LoadTypeEngines()
        {
            
            typeEngines = await TypeEngineService.GetAllAsync();
        }

        private async Task Save()
        {
            try
            {
                isSaving = true;
                if (ConnectionId.HasValue)
                    await DatabaseOptionService.UpdateAsync(connectionToEdit);
                else
                    await DatabaseOptionService.CreateAsync(connectionToEdit);
                Close();
            }
            catch(Exception ex)
            {
                NotificationExtensions.NotifyError(NotificationService, "Error en operacion", $"Error: {ex.Message}");
            }
            finally
            {
                isSaving = false;
            }
        }

        private void Close()
        {
            if (LoadConnections.HasDelegate)
                LoadConnections.InvokeAsync();
            DialogService.Close();
        }

        private async Task OnEngineTypeChange()
        {
            
            int typeEngineId = connectionToEdit.TypeEngineId.HasValue?connectionToEdit.TypeEngineId.Value:-1;
            var typeEngineSelected = await TypeEngineService.FindAsync(typeEngineId);
            if(typeEngineSelected==null)
            {
                return;
            }

            connectionToEdit.Port = typeEngineSelected.DefaultPort;
            hasSqlOptions = typeEngineSelected.HasSqlOptions;
        }
    }
}
