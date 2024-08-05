using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models
{
    public class Campaign
    {
        [Key]
        public long Id { get; set; }
       [Required]
        public string? Name { get; set; }
       [Required]
        public DateOnly StartDate { get; set; }
        [Required]
        public DateOnly EndDate { get; set; }
       [Required]
        public bool Status {  get; set; }
        public DateTime UpdatedOn {  get; set; }
    }
}
