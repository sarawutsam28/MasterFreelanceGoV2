using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class EmployerRating
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Rating_ID { get; set; }
        public int? Employer_ID { get; set; }
        [ForeignKey("Employer_ID")]
        public Employer Employer { get; set; }
        public int? Company_ID { get; set; }
        [ForeignKey("Company_ID")]
        public Company Company { get; set; }
        [Required]
        public int? Freelance_ID { get; set; }
        [ForeignKey("Freelance_ID")]
        public Freelance Freelance { get; set; }
        public int? Project_ID { get; set; }
        [ForeignKey("Project_ID")]
        public Project Project { get; set; }
        [Required]
        public int Score { get; set; }
        public string TextReview { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date_Create { get; set; }
        [Required]
        public bool DelStatus { get; set; }
    }
}