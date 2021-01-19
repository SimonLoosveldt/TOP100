using System.Collections.Generic;
using TopHundred.Models;
using TopHundred.Views.FrontendLogic;
using TopHundred.Views.ViewModels;

namespace TopHundred.Views.Services
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
