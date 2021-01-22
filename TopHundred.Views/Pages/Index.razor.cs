using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopHundred.Controllers.Services;

namespace TopHundred.Views.Pages
{
    public partial class Index
    {
        private readonly string loginPath = "/login";

        public Index()
        {

        }

        [Inject]
        public IUserService userService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string PageTitle { get; set; } = "INFO";

        protected override void OnInitialized()
        {
            if (!userService.IsLoggedIn())
            {
                HandleNotLoggedIn();
            }
        }

        public void HandleNotLoggedIn()
        {
            NavigationManager.NavigateTo(loginPath, true);
        }
    }
}
