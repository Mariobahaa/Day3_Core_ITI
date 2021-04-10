using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace Day3_Core_ITI.Models
{
    public class Track
    {
        [Key]
        public int  ID  {get; set;}
        public string Name  {get; set;}
        public string Description  {get; set;}

        public virtual ICollection<Trainee> Trainees { get; set; }

        public virtual ICollection<CourseTrack> CourseTracks { get; set; } 
        = new HashSet<CourseTrack>();
    }
}
