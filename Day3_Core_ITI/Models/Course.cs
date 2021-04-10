using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day3_Core_ITI.Models
{
    public class Course
    {
        [Key]
        public int ID {get; set;}
        public string Topic {get; set;}
        public float Grade { get; set; }

        public ICollection<CourseTrack> CourseTrack { get; set; }
        = new HashSet<CourseTrack>();
    }
}
