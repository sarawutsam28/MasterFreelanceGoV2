using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class Freelance
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Freelance_ID { get; set; }

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

        public string ImgName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date_Create { get; set; }
        [Required]
        public DateTime Date_Update { get; set; }
        [Required]
        public bool DelStatus { get; set; }
        public List<FreelanceSkill> FreelanceSkill { get; set; }
        public List<Auction> Auction { get; set; }
    }
}