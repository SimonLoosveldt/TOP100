using System;
using System.Collections.Generic;
using TopHundred.Core.Services;
using TopHundred.Core.ViewModels;
using System.Threading;
using Microsoft.AspNetCore.Components;
using TopHundred.Core.Controllers;
using TopHundred.Core.Entities;

namespace TopHundred.Views.Pages
{
    public partial class Input
    {
        private readonly string loginPath = "/login";

        // Parameters
        [Parameter]
        public string Param { get; set; }

        //Services
        [Inject]
        public UserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public InputController InputController { get; set; }

        // Properties
        public string PageTitle { get; set; } = "TOP100";
        public int UpperLimit { get; set; }
        public int LowerLimit { get; set; }
        public string SaveButtonLabel { get; set; } = "SAVE";
        public static List<ListEntryViewModel> userListEntries { get; set; }

        protected override void OnInitialized()
        {
            if (!UserService.IsLoggedIn())
            {
                HandleNotLoggedIn();
            }

            var boundaries = Param.Split('_');

            UpperLimit = int.Parse(boundaries[0]);
            LowerLimit = int.Parse(boundaries[1]);

            userListEntries = InputController.GetPreviousData(UserService.GetCurrentUser(), UpperLimit, LowerLimit);

            Thread syncThread = new Thread(SyncToDatabase);
            syncThread.Start();
        }

        private void UpdateDatabase()
        {
            SaveButtonLabel = "PRESSED";
            InputController.Sync(UserService.GetCurrentUser(), userListEntries);
        }

        public void HandleNotLoggedIn()
        {
            NavigationManager.NavigateTo(loginPath, true);
        }

        static void SyncToDatabase(Object obj)
        {
            var autoEvent = new AutoResetEvent(false);
            //var updateService = new UpdateService(inputHandler, userListEntries);

            Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")} --> Creating timer...");
            //var stateTimer = new Timer(updateService.Update, autoEvent, 30000, 60000);
        }
    }
}
