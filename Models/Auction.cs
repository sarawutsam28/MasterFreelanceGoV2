using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace FreelanceGo_MasterV2.Models
{
    public class Auction
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Auction_ID { get; set; }
        public int Freelance_ID { get; set; }

        [ForeignKey("Freelance_ID")]
        public Freelance Freelance { get; set; }
        public int Project_ID { get; set; }

        [ForeignKey("Project_ID")]
        public Project Project { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int AuctionTime { get; set; }
        public DateTime Date_Create { get; set; }
    }
}