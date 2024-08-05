using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models
{
    public class UserDetails
    {
        public long Id { get; set; }
        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(10)]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Status { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
