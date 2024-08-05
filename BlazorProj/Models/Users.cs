using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models
{
    public class Users
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
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
        public string? Role { get; set; }

    }
    
}
