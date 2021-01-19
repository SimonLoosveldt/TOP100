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
        private readonly InputHandler inputHandler;
        private List<ListEntryViewModel> ListEntries { get; set; }
        public int Count { get; set; } = 0;

        public UpdateService(InputHandler inputHandler, List<ListEntryViewModel> listEntries)
        {
            this.inputHandler = inputHandler;
            this.ListEntries = listEntries;
        }

        public void Update(Object stateinfo)
        {
            //AutoResetEvent autoEvent = (AutoResetEvent)stateinfo;
            Console.WriteLine($"{Count}: Updating database @{DateTime.Now:HH:mm:ss.fff}");
        }
    }
}
