using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TopHundred.Views.FrontendLogic;
using TopHundred.Views.ViewModels;

namespace TopHundred.Views.Services
{
    public class UpdateService : IUpdateService
    {
        private InputHandler InputHandler { get; set; }
        private List<ListEntryViewModel> ListEntries { get; set; }
        public int Count { get; set; } = 0;

        public UpdateService(InputHandler inputHandler, List<ListEntryViewModel> listEntries)
        {
            this.InputHandler = inputHandler;
            this.ListEntries = listEntries;
        }

        public void Update(Object stateinfo)
        {

            AutoResetEvent autoEvent = (AutoResetEvent)stateinfo;
            Console.WriteLine($"{Count}: Updating database @{DateTime.Now.ToString("HH:mm:ss.fff")}");
        }

    }
}
