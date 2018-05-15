using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.ViewModels
{
    public class SkillList
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int skill_ID { get; set; }
        public string name { get; set; }
        public string skill_Description { get; set; }
        public DateTime date_Create { get; set; }
        public DateTime date_Update { get; set; }
        public bool delStatus { get; set; }
    }
}