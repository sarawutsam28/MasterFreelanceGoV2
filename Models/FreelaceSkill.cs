using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class FreelanceSkill
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FreelanceSkill_ID { get; set; }
        public int Freelance_ID { get; set; }

        [ForeignKey("Freelance_ID")]
        public Freelance Freelance { get; set; }
        public int Skill_ID { get; set; }

        [ForeignKey("Skill_ID")]
        public Skill Skill { get; set; }
        public DateTime Date_Create { get; set; }
        public DateTime Date_Update { get; set; }
        public bool DelStatus { get; set; }
    }
}