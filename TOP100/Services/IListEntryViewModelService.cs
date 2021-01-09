using Globals;
using System.Collections.Generic;
using TOP100.ViewModels;

namespace TOP100.Services
{
    public interface IListEntryViewModelService
    {
        List<ListEntryViewModel> ListEntryViewModels { get; set; }

        void SyncWithDatabase(User user);
    }
}