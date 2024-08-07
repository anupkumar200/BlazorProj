using System.ComponentModel.DataAnnotations;

namespace BlazorProj.Models.DTOs
{
    public class GroceryStoreDTO
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
