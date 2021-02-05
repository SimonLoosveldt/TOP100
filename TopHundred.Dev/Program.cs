using System;
using System.Linq;
using TopHundred.Core.Entities;
using TopHundred.Core.Repositories;

namespace TopHundred.Dev
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new TopContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TOP100;Integrated Security=True");

            var listEntryRepo = new ListEntryRepository(context);
            var trackRepo = new TrackRepository(context);


            var tracks = trackRepo.GetAll().ToList();
            Console.WriteLine("--------------------------> Show all tracks... <--------------------------");
            foreach(var track in tracks)
            {
                Console.WriteLine(track.ToString());
            }
            Console.WriteLine("--------------------------> End show all tracks <------------------------");

            var listEntries = listEntryRepo.GetAll().ToList();
            Console.WriteLine("--------------------------> Show all listentries... <--------------------------");
            foreach (var listEntry in listEntries)
            {
                Console.WriteLine(listEntry.ToString());
            }
            Console.WriteLine("--------------------------> End show all listentries... <-----------------------");

            Console.Read();

        }
    }
}
