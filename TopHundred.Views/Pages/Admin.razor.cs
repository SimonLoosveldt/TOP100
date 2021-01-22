using TopHundred.Core.Controllers;
using TopHundred.Core.Entities;

namespace TopHundred.Views.Pages
{
    public partial class Admin
    {
        private readonly TopContext _topContext;

        public Admin(TopContext topContext)
        {
            _topContext = topContext;
        }

        public string pageTitle { get; set; } = "ADMINPANEL";

        public int SubmissionEntries { get; set; } = 0;
        public int CompletedEntries { get; set; } = 0;
        public int DifferentSongs { get; set; } = 0;
        public int NonSpotifySongs { get; set; } = 0;

        protected override void OnInitialized()
        {
            var adminController = new AdminController(_topContext);

            SubmissionEntries = adminController.GetCountSubmissionEntries();
            CompletedEntries = adminController.GetCountCompletedEntries();
            DifferentSongs = adminController.GetCountTracks();
            NonSpotifySongs = adminController.GetCountNonSpotifyTracks();
        }
    }
}
