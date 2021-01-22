using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TopHundred.Core.Services;
using TopHundred.Core.Exceptions;
using TopHundred.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using TopHundred.Core.Entities;

namespace TopHundred.Views.Pages
{
    public partial class Login
    {
        // Private
        private readonly TopContext _topContext;

        public Login(TopContext topContext)
        {
            _topContext = topContext;
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
        private UserRepository UserRepository { get; set; }

        // Protected
        protected override void OnInitialized()
        {
            UserRepository = new UserRepository(_topContext);
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
                    UserService.Login(UserRepository.GetUserByName(InputFirstName, InputLastname));
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
