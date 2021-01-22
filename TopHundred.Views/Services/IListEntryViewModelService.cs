using System.Collections.Generic;
using TopHundred.Core.Entities;
using TopHundred.Core.ViewModels;

namespace TopHundred.Views.Services
{
    public interface IListEntryViewModelService
    {
        List<ListEntryViewModel> ListEntryViewModels { get; set; }

        void SyncWithDatabase(User user);
    }
}