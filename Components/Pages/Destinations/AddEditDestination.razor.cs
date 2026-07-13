using Microsoft.AspNetCore.Components;
using Radzen;
using SGC_Database_Backup.Components.Dialogs;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Repositories.Destinations;

namespace SGC_Database_Backup.Components.Pages.Destinations
{
    public partial class AddEditDestination
    {
        [Parameter]
        public int? DestinationId { get; set; }

        [Parameter]
        public EventCallback LoadDestinations { get; set; }

        [Inject]
        private IDestinationRepository DestinationService { get; set; }

        [Inject]
        private IDestinationTypeRepository DestinationTypeService { get; set; }

        [Inject]
        private DialogService DialogService { get; set; }

        private Destination? destinationToEdit = new();
        private List<DestinationType> destinationTypes = [];
        private bool canBrowse = false;

        private bool isLoading = false;
        private bool isSaving = false;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;
                destinationTypes = (await DestinationTypeService.GetAllAsync()).ToList();
                destinationToEdit = DestinationId.HasValue
                    ? await DestinationService.FindAsync(DestinationId.Value)
                    : new Destination();
                UpdateCanBrowse();
            }
            finally
            {
                isLoading = false;
            }
        }

        private void UpdateCanBrowse()
        {
            var selectedType = destinationTypes.FirstOrDefault(t => t.Id == destinationToEdit?.DestinationTypeId);
            canBrowse = selectedType?.Description?.Equals("Local", StringComparison.OrdinalIgnoreCase) == true
                        || selectedType?.Description?.Equals("Ftp", StringComparison.OrdinalIgnoreCase) == true;
        }

        private void OnDestinationTypeChanged(object value)
        {
            UpdateCanBrowse();
            StateHasChanged();
        }

        private async Task BrowseFolder()
        {
            if (destinationToEdit == null) return;

            var selectedType = destinationTypes.FirstOrDefault(t => t.Id == destinationToEdit.DestinationTypeId);
            if (selectedType == null) return;

            var isLocal = selectedType.Description.Equals("Local", StringComparison.OrdinalIgnoreCase);

            var parameters = new Dictionary<string, object?>
            {
                { "CurrentPath", destinationToEdit.Path },
                { "Mode", isLocal ? BrowseMode.Local : BrowseMode.Ftp }
            };

            if (!isLocal)
            {
                parameters["FtpHost"] = destinationToEdit.Host;
                parameters["FtpPort"] = destinationToEdit.Port > 0 ? destinationToEdit.Port : 21;
                parameters["FtpUser"] = destinationToEdit.UserName;
                parameters["FtpPassword"] = destinationToEdit.Password;
            }

            var title = isLocal ? "Examinar carpeta local" : "Examinar carpeta FTP";
            var result = await DialogService.OpenAsync<FolderBrowser>(title, parameters);

            if (result != null)
            {
                destinationToEdit.Path = result.ToString();
                StateHasChanged();
            }
        }

        private async Task Save()
        {
            try
            {
                isSaving = true;
                if (DestinationId.HasValue)
                    await DestinationService.UpdateAsync(destinationToEdit);
                else
                    await DestinationService.CreateAsync(destinationToEdit);
                Close();
            }
            finally
            {
                isSaving = false;
            }
        }

        private void Close()
        {
            if (LoadDestinations.HasDelegate)
                LoadDestinations.InvokeAsync();
            DialogService.Close();
        }
    }
}
