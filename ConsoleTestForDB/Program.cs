using TopHundred.Models;
using TopHundred.Controllers;
using System;

namespace ConsoleTestForDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var topContext = new TopContext();
            var userParser = new UserParser(topContext);
            var trackParser = new TrackParser(topContext);
            var artistParser = new ArtistParser(topContext);
            var listEntryParser = new ListEntryParser(topContext);

            var users = userParser.GetAllUsers();
            Console.WriteLine("\n<------------------------------------------>\n\tGetAllUsers()\n<------------------------------------------>\n");
            foreach(User user in users)
            {
                Console.WriteLine(user);
            }

            var listEntries = userParser.GetListEntriesFromUserById(1);
            Console.WriteLine("\n<------------------------------------------>\n\tGetListEntriesFromUserById()\n<------------------------------------------>\n");
            foreach(ListEntry listEntry in listEntries)
            {
                Console.WriteLine(listEntry);
            }

            var tracks = trackParser.GetAllTracks();
            Console.WriteLine("\n<------------------------------------------>\n\tGetAllTracks()\n<------------------------------------------>\n");
            foreach (Track track in tracks)
            {
                Console.WriteLine(track.ToString());
            }

            //var arnaud = new User("Arnaud", "Bogaert", "1114741073");
            //Console.WriteLine("\n<------------------------------------------>\n\tAddUser()\n< ------------------------------------------>\n");
            //Console.WriteLine($"User to add: {arnaud}");
            //userParser.AddUser(arnaud);
            //Console.WriteLine("--> OK");

            var allListEntries = listEntryParser.GetAllListEntries();
            Console.WriteLine("\n<------------------------------------------>\n\tGetAllListEntries()\n<------------------------------------------>\n");
            foreach (ListEntry oneListEntry in allListEntries)
            {
                Console.WriteLine(oneListEntry);
            }

            Console.Read();
        }
    }
}
