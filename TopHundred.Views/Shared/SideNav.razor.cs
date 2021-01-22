using Microsoft.AspNetCore.Components;
using TopHundred.Core.Entities;
using TopHundred.Core.Services;

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
        public UserService UserService { get; set; }

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
