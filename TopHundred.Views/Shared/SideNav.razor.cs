using Microsoft.AspNetCore.Components;
using TopHundred.Core.Services;
using TopHundred.Models;

namespace TopHundred.Views.Shared
{
    public partial class SideNav
    {
        private readonly string inputHomePath = "/input/100_91";
        private readonly string homePath = "/home";
        private readonly string loginPath = "/login";

        public SideNav()
        {

        }

        // Services
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IUserService UserService { get; set; }

        // Properties
        public User LoggedInUser { get; set; }

        // Protected
        protected override void OnInitialized()
        {
            LoggedInUser = UserService.GetCurrentUser();
        }

        // Public
        public void LogInPressed()
        {
            HandlePageChange(loginPath);
        }

        public void LogOutPressed()
        {
            UserService.Logout();
            HandlePageChange(loginPath);
        }
        public void HandlePageChange(string path)
        {
            NavigationManager.NavigateTo(path, true);
        }
    }
}
