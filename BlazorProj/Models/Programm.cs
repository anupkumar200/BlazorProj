using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models
{
    public class Programm
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CaseManager { get; set; }
        [Required]
        public bool Status { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
