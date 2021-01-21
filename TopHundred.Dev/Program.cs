using TopHundred.Models;
using TopHundred.Controllers;
using System;

namespace TopHundred.Dev
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var topContext = new TopContext();
            var userController = new UserController(topContext);
            var trackController = new TrackController(topContext);
            var artistController = new ArtistController(topContext);
            //var artistParser = new ArtistParser(topContext);
            var listEntryParser = new ListEntryController(topContext);

            var users = userController.GetAllUsers();
            Console.WriteLine("\n<------------------------------------------>\n\tGetAllUsers()\n<------------------------------------------>\n");
            foreach(User user in users)
            {
                Console.WriteLine(user);
            }

            //var listEntries = userController.GetListEntriesFromUserById(1);
            //Console.WriteLine("\n<------------------------------------------>\n\tGetListEntriesFromUserById()\n<------------------------------------------>\n");
            //foreach(ListEntry listEntry in listEntries)
            //{
            //    Console.WriteLine(listEntry);
            //}

            var tracks = trackController.GetAllTracks();
            Console.WriteLine("\n<------------------------------------------>\n\tGetAllTracks()\n<------------------------------------------>\n");
            foreach (Track track in tracks)
            {
                Console.WriteLine(track.ToString());
            }

            //var arnaud = new User("arnaud", "bogaert", "1114741073");
            //Console.WriteLine("\n<------------------------------------------>\n\tAddUser()\n< ------------------------------------------>\n");
            //Console.WriteLine($"User to add: {arnaud}");
            //userController.AddUser(arnaud);
            //Console.WriteLine("--> OK");

            var allListEntries = listEntryParser.GetAllListEntries();
            Console.WriteLine("\n<------------------------------------------>\n\tGetAllListEntries()\n<------------------------------------------>\n");
            foreach (ListEntry oneListEntry in allListEntries)
            {
                Console.WriteLine(oneListEntry);
            }

            var tracksOfArtist = artistController.GetTracksFromArtistById(5);
            Console.WriteLine("\n<------------------------------------------>\n\tGetTracksFromArtistById()\n<------------------------------------------>\n");
            foreach (Track track in tracksOfArtist)
            {
                Console.WriteLine(track);
            }

            Console.ReadKey();
        }
    }
}
