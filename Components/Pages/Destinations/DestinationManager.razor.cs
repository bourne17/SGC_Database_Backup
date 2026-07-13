using Microsoft.AspNetCore.Components;
using Radzen;
using SGC_Database_Backup.Components.Extensions;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Destinations;

namespace SGC_Database_Backup.Components.Pages.Destinations
{
    public partial class DestinationManager
    {
        [Inject]
        private IDestinationRepository DestinationService { get; set; }

        [Inject]
        private DialogService DialogService { get; set; }

        [Inject]
        private NotificationService NotificationService { get; set; }

        private IEnumerable<Destination> destinations = [];
        private bool isLoading = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadDestinations();
        }

        private async Task LoadDestinations()
        {
            try
            {
                isLoading = true;
                destinations = await DestinationService.GetAllAsync();
            }
            finally
            {
                isLoading = false;
            }
        }

        private async Task EditDestination(int id)
        {
            await DialogService.OpenAsync<AddEditDestination>("Editar destino", new Dictionary<string, object?>
            {
                { "DestinationId", id },
                { "LoadDestinations", EventCallback.Factory.Create(this, LoadDestinations) }
            });
        }

        private async Task AddDestination()
        {
            await DialogService.OpenAsync<AddEditDestination>("Agregar destino", new Dictionary<string, object?>
            {
                { "LoadDestinations", EventCallback.Factory.Create(this, LoadDestinations) }
            });
        }

        private async Task DeleteDestination(int id)
        {
            try
            {
                isLoading = true;
                await DestinationService.DeleteAsync(id);
                NotificationExtensions.NotifySuccess(NotificationService, "Eliminado", "El destino se eliminó correctamente.");
                await LoadDestinations();
            }
            catch (Exception ex)
            {
                NotificationExtensions.NotifyError(NotificationService, "Error", $"No se pudo eliminar el destino: {ex.Message}");
            }
            finally
            {
                isLoading = false;
            }
        }
    }
}
