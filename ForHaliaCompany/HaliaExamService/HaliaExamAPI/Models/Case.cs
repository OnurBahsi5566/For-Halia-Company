using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaliaExamAPI.Models
{
    public class Case
    {
        [Key]
        public int id { get; set; }

        
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        
        [Required]
        public string description { get; set; }

        
        [Required]
        public DateTime startdate { get; set; }

        
        [Required]
        public DateTime finishdate { get; set; }

        
        [StringLength(15)]
        public string status { get; set; }


        public int? openeduserid { get; set; }


        [ForeignKey("openeduserid")]
        public User User { get; set; }

    }
}