using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required]
        [MinLength(2)]
        [Display(Name= "First Name")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(2)]
        [Display(Name= "Last Name")]
        public string LastName {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name= "Email Address")]
        public string  Email {get;set;}

        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer, silly!")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name= "Confirm Password")]
        public string ConfirmPW {get;set;}

        public List<RSVP> WeddingList {get;set;} = new List<RSVP>();

        public DateTime Created_At {get;set;} = DateTime.Now;

        public DateTime Updated_At {get;set;} = DateTime.Now;
        
    }
}

