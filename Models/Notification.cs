using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class Notification
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Notification_ID { get; set; }
        [Required]
        public int? Company_ID { get; set; }

        [ForeignKey("Company_ID")]
        public Company Company { get; set; }
        [Required]
        public int? Employer_ID { get; set; }

        [ForeignKey("Employer_ID")]
        public Employer Employer { get; set; }
        [Required]
        public int? Freelance_ID { get; set; }

        [ForeignKey("Freelance_ID")]
        public Freelance Freelance { get; set; }
        [Required]
        public int NotificationCode { get; set; }
        [Required]
        public bool ReadStatus { get; set; }
        [Required]
        public string NotificationText { get; set; }
        [Required]
        public DateTime Date_Create { get; set; }
        [Required]
        public bool DelStatus { get; set; }
    }
}