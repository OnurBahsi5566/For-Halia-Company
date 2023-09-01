using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HaliaExamAPI.Models
{
    public class AssignedCase
    {
        [Key]
        public int id { get; set; }

        
        public int caseid { get; set; }

        
        public int assigneduserid { get; set; }

        
        [Required]
        public string description { get; set; }


        [StringLength(15)]
        public string status { get; set; }

       
        public int? actioneduserid { get; set; }

        
        [ForeignKey("caseid")]
        public Case Case { get; set; }

        
        [ForeignKey("assigneduserid")]
        public User AssignedUser { get; set; }

        
        [ForeignKey("actioneduserid")]
        public User ActionedUser { get; set; }
    }
}