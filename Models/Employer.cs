using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class Employer
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Employer_ID { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }
        public string ID_Card { get; set; }
        public int Rating { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string Facebook { get; set; }
        public string Line { get; set; }
        public string Address { get; set; }
        public string imgName { get; set; }
        public DateTime Date_Create { get; set; }
        public DateTime Date_Update { get; set; }

        public bool DelStatus { get; set; }
    }
}