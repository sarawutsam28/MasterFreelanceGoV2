using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class ProjectSkill
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ProjectSkill_ID { get; set; }
        public int Project_ID { get; set; }

        [ForeignKey("Project_ID")]
        public Project Project { get; set; }
        public int Skill_ID { get; set; }

        [ForeignKey("Skill_ID")]
        public Skill Skill { get; set; }
        [Required]
        public DateTime Date_Create { get; set; }
        [Required]
        public DateTime Date_Update { get; set; }
        [Required]
        public bool DelStatus { get; set; }

    }
}