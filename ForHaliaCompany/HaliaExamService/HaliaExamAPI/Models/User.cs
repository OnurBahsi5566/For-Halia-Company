using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HaliaExamAPI.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        
        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        
        [Required]
        [StringLength(50)]
        public string lastname { get; set; }
        
       
        [Required]
        [StringLength(50)]
        public string email { get; set; }

        
        [Required]
        [StringLength(15)]
        public string phone { get; set; }

        
        [Required]
        [StringLength(50)]
        public string password { get; set; }

    }
}