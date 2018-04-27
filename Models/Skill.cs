using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class Skill
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Skill_ID { get; set; }
        public string Name { get; set; }
        public string Skill_Description { get; set; }
        public DateTime Date_Create { get; set; }
        public DateTime Date_Update { get; set; }
        public bool DelStatus { get; set; }
    }
}