

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get;set; }

        [Required]
        [MinLength(2)]
        public string Wedder_1 { get;set; }
        
        [Required]
        [MinLength(2)]
        public string Wedder_2 { get;set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get;set; }

        [Required]
        public string Address { get;set; }

        public int CreatorId { get;set; }

        public List<RSVP> GuestList { get;set; } = new List<RSVP>();

        [NotMapped]
        public int GuestCount {
            get{
                int Count = 0;
                foreach (var guest in GuestList){
                    Count += 1;
                }
                return Count;
            }
        }

        public DateTime Created_At { get;set; } = DateTime.Now;

        public DateTime Updated_At { get;set; } = DateTime.Now;
    }
}
