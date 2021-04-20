using Microsoft.AspNetCore.Components;
using Radzen;
using Serilog;
using System.Threading.Tasks;

namespace LoggerTest.Pages
{
    public partial class Sandbox
    {
        [Inject] NotificationService NotificationService { get; set; }
        private string _errorMessage;
        private string _informationMessage;

        private async Task LetError()
        {
            Log.Error(_errorMessage);
            _errorMessage = null;

            await Notify("Error handled.");
        }

        private async Task LetInformation()
        {
            Log.Information(_informationMessage);
            _informationMessage = null;

            await Notify("Information handled.");
        }

        private async Task Notify(string message)
        {
            await ShowNotification(new NotificationMessage
            {
                Detail = message,
                Duration = 4000,
                Severity = NotificationSeverity.Info,
                Summary = "Info Box"
            });
        }

        protected async Task ShowNotification(NotificationMessage message)
        {
            NotificationService.Notify(message);
            await InvokeAsync(() => { StateHasChanged(); });
        }

    }
}
