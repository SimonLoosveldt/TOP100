using Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TOP100.FrontendLogic;
using TOP100.ViewModels;

namespace TOP100.Services
{
    public class ListEntryViewModelService : IListEntryViewModelService
    {
        private InputHandler inputHandler;

        public List<ListEntryViewModel> ListEntryViewModels { get; set; }

        public ListEntryViewModelService()
        {
            inputHandler = new InputHandler();
        }

        public void SyncWithDatabase(User user)
        {
            inputHandler.UpdateDatabase(user, ListEntryViewModels);
        }

    }
}
