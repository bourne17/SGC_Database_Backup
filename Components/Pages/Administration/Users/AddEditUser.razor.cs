using Microsoft.AspNetCore.Components;
using Radzen;
using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Services.Users;

namespace SGC_Database_Backup.Components.Pages.Administration.Users
{
    public partial class AddEditUser
    {
        [Parameter]
        public int? UserId { get; set; }

        [Parameter]
        public EventCallback LoadUsers { get; set; }

        [Inject]
        private IUserService UserService { get; set; }
        [Inject]
        private DialogService DialogService { get; set; }

        private User? userToEdit = new();

        private bool isLoading = false;
        private bool isSaving = false;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                isLoading = true;
                userToEdit = UserId.HasValue ? await UserService.FindByIdAsync(UserId.Value) : new();
            }
            finally
            {
                isLoading = false;
            }
            
        }

        private async Task Save()
        {
            try
            {
                isSaving = true;
                await UserService.SaveChanges(userToEdit);
                Close();
            }
            finally
            {
                isSaving = false;
            }
        }
        private void Close()
        {
            if(LoadUsers.HasDelegate)
            {
                LoadUsers.InvokeAsync();
            }
            DialogService.Close();
        }
    }
}
