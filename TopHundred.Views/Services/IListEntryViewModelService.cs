using TopHundred.Models;
using System.Collections.Generic;
using TopHundred.Models.ViewModels;

namespace TopHundred.Views.Services
{
    public interface IListEntryViewModelService
    {
        List<ListEntryViewModel> ListEntryViewModels { get; set; }

        void SyncWithDatabase(User user);
    }
}