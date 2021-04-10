using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day3_Core_ITI.Models
{
    public class Trainee
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        public string MobileNo { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public int TrackId {get; set;}

        [ForeignKey("TrackId")]
        public virtual Track Track {get; set;}
    }
}
