using Day3_Core_ITI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3_Core_ITI.Models;
using ServiceStack;

namespace Day3_Core_ITI.Services
{
    public class TracksRepoService : ITracksRepositry
    {
        private readonly TracksContext context;

        public TracksRepoService(TracksContext context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            context.Remove(context.Tracks.Find(id));
            context.SaveChanges();
        }

        public bool Exists(int? id)
        {
            return context.Tracks.Any(e => e.ID == id);
        }

        public List<Track> GetAll()
        {
            return context.Tracks.ToList();

        }

        public Track GetDetails(int? id)
        {
            return context.Tracks.Find(id);

        }

    

        public void Insert(Track track)
        {
            context.Tracks.Add(track);
            context.SaveChanges();
        }

        public void Update(int id, Track track)
        {
            Track trackUpdated = context.Tracks.Find(id);
            trackUpdated.Name = track.Name;
            trackUpdated.Description = track.Description;
            trackUpdated.CourseTracks = track.CourseTracks;
            trackUpdated.Trainees = track.Trainees;


            context.SaveChanges();
        }

     
    }
}
