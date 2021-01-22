using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopHundred.Core.Entities;
using TopHundred.Core.Exceptions;

namespace TopHundred.Core.Repositories
{
    public class ReleaseDateInfoRepository
    {
        private readonly TopContext db;
        public ReleaseDateInfoRepository(TopContext topContext)
        {
            this.db = topContext;
        }

        public void AddReleaseDateInfo(ReleaseDateInfo releaseDateInfo)
        {
            db.ReleaseDateInfos.Add(releaseDateInfo);
            db.SaveChanges();
        }

        public void AddNewReleaseDateInfo(string releaseDate, string releaseDatePrecision, Track track)
        {
            db.ReleaseDateInfos.Add(new ReleaseDateInfo(releaseDate, releaseDatePrecision, track));
            db.SaveChanges();
        }

        public ReleaseDateInfo GetReleaseDateInfoFromTrack(Track track)
        {
            return db.ReleaseDateInfos.Where(x => x.Track.Id == track.Id).FirstOrDefault() ?? throw new ReleaseDateInfoNotFoundException($"No release date info about track:{track} in database.");
        }

        public void UpdateReleaseDateInfo(ReleaseDateInfo releaseDateInfo)
        {
            db.ReleaseDateInfos.Update(releaseDateInfo);
            db.SaveChanges();
        }

        public void DeleteReleaseDateInfo(ReleaseDateInfo releaseDateInfo)
        {
            db.ReleaseDateInfos.Remove(releaseDateInfo);
            db.SaveChanges();
        }
    }
}
