using System;
using System.Collections.Generic;
using TopHundred.Core;
using TopHundred.Core.ViewModels;

namespace TopHundred.Views.Services
{
    public class UpdateService : IUpdateService
    {
        private readonly InputController inputController;
        private List<ListEntryViewModel> ListEntries { get; set; }
        public int Count { get; set; } = 0;

        public UpdateService(InputController inputController, List<ListEntryViewModel> listEntries)
        {
            this.inputController = inputController;
            this.ListEntries = listEntries;
        }

        public void Update(Object stateinfo)
        {
            //AutoResetEvent autoEvent = (AutoResetEvent)stateinfo;
            Console.WriteLine($"{Count}: Updating database @{DateTime.Now:HH:mm:ss.fff}");
        }
    }
}
