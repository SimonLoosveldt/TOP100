using System.Collections.Generic;
using TopHundred.Controllers;
using TopHundred.Models;
using TopHundred.Models.ViewModels;

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
