using System.Collections.Generic;
using TopHundred.Core;
using TopHundred.Core.Entities;
using TopHundred.Core.ViewModels;

namespace TopHundred.Views.Services
{
    public class ListEntryViewModelService : IListEntryViewModelService
    {
        private readonly InputController inputHandler;

        public List<ListEntryViewModel> ListEntryViewModels { get; set; }

        public ListEntryViewModelService()
        {
            inputHandler = new InputController();
        }

        public void SyncWithDatabase(User user)
        {
            inputHandler.UpdateDatabase(user, ListEntryViewModels);
        }

    }
}
