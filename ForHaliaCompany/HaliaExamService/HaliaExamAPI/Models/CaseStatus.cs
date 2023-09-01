using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaliaExamAPI.Models
{
    public class CaseStatus
    {
        [Key]
        public int id { get; set; }

       
        public int caseid { get; set; }

        
        public DateTime date { get; set; }

        
        [Required]
        [StringLength(15)]
        public string status { get; set; }

        
        public string statusdescription { get; set; }

       
        public int actioneduserid { get; set; }

        
        [ForeignKey("caseid")]
        public Case Case { get; set; }

        
        [ForeignKey("actioneduserid")]
        public User User { get; set; }
    }
}