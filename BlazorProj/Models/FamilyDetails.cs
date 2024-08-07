using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models
{
    public class FamilyDetails
    {
        [Key]
        public long FamilyHeadId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]

        public int Age { get; set; }
        [Required]
        public string Gender { get; set; } 
        [Required(ErrorMessage ="Please select relation")]
        public string RelationId { get; set; } 
        [Required]
        public string Description { get; set; }
    }
}
