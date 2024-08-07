using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models
{
    public class Family
    {
        [Key] 
        public long FamilyHeadId { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; } 
        [Required]
        public string Relation { get; set; } 
        [Required]
        public string Description { get; set; } 
    }
}
