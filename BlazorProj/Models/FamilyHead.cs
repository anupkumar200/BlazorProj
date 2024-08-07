using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProj.Models
{
    public class FamilyHead
    {
        public int CampaignId { get; set; }
        [ForeignKey("CampaignId")]
        public Campaign? Campaign { get; set; }        
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]
        public Programm? Program { get; set; }
        public int GroceryStoreId { get; set; }
        [ForeignKey("GroceryStoreId")]
        public GroceryStores? GroceryStores { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
