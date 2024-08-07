using BlazorProj.Clients.GroceryStore;
using BlazorProj.Clients.Programs;
using BlazorProj.Components.Pages.GroceryStores;
using BlazorProj.Models;

namespace BlazorProj.Clients.Families
{
    public class FamilyHeadService
    {
        private readonly Campaign[] campaigns = new CampaignClients().GetCampaigns();
        private readonly GroceryStores[] groceryStores = new GroceryStoreClients().GetGroceryStore();
        private readonly Programm[] programms = new ProgramClients().GetProgram();
    }
}
