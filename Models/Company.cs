using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class Company
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Company_ID { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public string Company_Name { get; set; }
        public string Fax { get; set; }
        public int Rating { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string Company_Tel { get; set; }
        public string Facebook { get; set; }
        public string Line { get; set; }
        public string Company_Address { get; set; }
        public string imgName { get; set; }
        public string Company_TaxID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date_Create { get; set; }
        public DateTime Date_Update { get; set; }
        public bool DelStatus { get; set; }
    }
}