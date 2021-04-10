using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Day3_Core_ITI.Models
{
    public class CourseTrack
    {
   
        public int CourseId { get; set; }
        public int TackId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [ForeignKey("TrackId")]
        public Track Track { get; set; }

    }
}
