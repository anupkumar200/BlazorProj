using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models
{
    public class CampaignDetails
    {        
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
        [Required]
        public bool Status { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
