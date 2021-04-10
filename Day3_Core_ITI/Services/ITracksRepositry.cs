using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day3_Core_ITI.Models;

namespace Day3_Core_ITI.Services
{
    public interface ITracksRepositry
    {
        public List<Track> GetAll();
        public Track GetDetails(int? id);
        public void Insert(Track track);
        public void Update(int id, Track track);
        public void Delete(int id);
        //object GetDetails(int? id);

        public bool Exists(int? id);
    }
}
