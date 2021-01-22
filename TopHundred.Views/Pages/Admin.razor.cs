using TopHundred.Core;

namespace TopHundred.Views.Pages
{
    public partial class Admin
    {
        public Admin()
        {

        }

        public string pageTitle { get; set; } = "ADMINPANEL";

        public int SubmissionEntries { get; set; } = 0;
        public int CompletedEntries { get; set; } = 0;
        public int DifferentSongs { get; set; } = 0;
        public int NonSpotifySongs { get; set; } = 0;

        protected override void OnInitialized()
        {
            var adminController = new AdminController();

            SubmissionEntries = adminController.GetCountSubmissionEntries();
            CompletedEntries = adminController.GetCountCompletedEntries();
            DifferentSongs = adminController.GetCountTracks();
            NonSpotifySongs = adminController.GetCountNonSpotifyTracks();
        }
    }
}
