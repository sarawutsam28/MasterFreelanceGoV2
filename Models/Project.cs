using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class Project
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Project_ID { get; set; }
        public int? Employer_ID { get; set; }
        [ForeignKey("Employer_ID")]
        public Employer Employer { get; set; }
        public int? Company_ID { get; set; }
        [ForeignKey("Company_ID")]
        public Company Company { get; set; }
        public int? Freelance_ID { get; set; }
        [ForeignKey("Freelance_ID")]
        public Freelance Freelance { get; set; }
        [Required]
        public string ProjectName { get; set; }

        [Required]
        public string Description { get; set; }
        [Required]
        public int Budget { get; set; }
        [Required]
        public int Timelength { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartingDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public int ProjectPrice { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ProjectTimeOut { get; set; }
        [Required]
        public bool ProjectStatus { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date_Create { get; set; }
        [Required]
        public DateTime Date_Update { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public bool DelStatus { get; set; }
        public List<ProjectSkill> ProjectSkill { get; set; }

    }
}