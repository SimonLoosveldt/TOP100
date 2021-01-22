using System.Threading.Tasks;
using TopHundred.Views.Services;
using TopHundred.Controllers.Services;
using TopHundred.Controllers.Exceptions;
using TopHundred.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TopHundred.Views.Pages
{
    public partial class Login
    {
        // Private
        private UserController userController { get; set; }

        public Login()
        {

        }

        // Services
        [Inject]
        public IAccountService AccountService { get; set; }
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public IErrorService ErrorService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        // Properties
        public string PageTitle { get; set; } = "AANMELDEN";
        public string LoginButtonLabel { get; set; } = "LOGIN";
        public string InputFirstName { get; set; } = string.Empty;
        public string InputLastname { get; set; } = string.Empty;

        // Protected
        protected override void OnInitialized()
        {
            userController = new UserController();
        }

        // Private
        private async void LoginPressed()
        {
            if (!InputFilledCheck())
            {
                await LaunchPopUp("Please fill in all fields...");
            }
            else
            {

                try
                {
                    UserService.Login(userController.GetUserByName(InputFirstName, InputLastname));
                    Redirect();
                }
                catch (UserNotFoundException)
                {
                    await LaunchPopUp("Unrecognized user...");
                }
            }
        }

        private async Task LaunchPopUp(string message)
        {
            // https://blazor-university.com/javascript-interop/
            await JSRuntime.InvokeVoidAsync("alert", message);
        }

        private bool InputFilledCheck()
        {
            return string.IsNullOrEmpty(InputFirstName) || string.IsNullOrEmpty(InputLastname) ? false : true;
        }

        private void Redirect()
        {
            NavigationManager.NavigateTo("/", true);
        }
    }
}
