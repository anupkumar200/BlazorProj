using BlazorProj.Models;

namespace BlazorProj.Clients.GroceryStore
{
    public class GroceryStoreClients
    {
        private readonly List<GroceryStores> groceryStores =
        [
            new(){
                Id = 1,
                Name = "Chandra Mart",               
                Status = true,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 2,
                Name = "Smart Shop",                
                Status = false,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 3,
                Name = "Dmart",                
                Status = true,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 4,
                Name = "Vishal Mega Mart",               
                Status = false,
                UpdatedOn = DateTime.Now
            },
            new(){
                Id = 5,
                Name = "V2",                
                Status = true,
                UpdatedOn = DateTime.Now
            }
        ];
        public GroceryStores[] GetGroceryStore() => [.. groceryStores];

        public void AddGroceryStore(GroceryStoreDetails objGrocery)
        {
            var grocery = new GroceryStores
            {
                Id = groceryStores.Count + 1,
                Name = objGrocery.Name,                
                Status = objGrocery.Status,
                UpdatedOn = DateTime.Now
            };
            groceryStores.Add(grocery);
        }
        public GroceryStoreDetails GetGrocery(long id)
        {
            GroceryStores grocery = GetGroceryStoreById(id);
            return new GroceryStoreDetails
            {
                Id= grocery.Id,
                Name = grocery.Name,
                Status = grocery.Status,
                UpdatedOn = DateTime.Now
            };
        }
        private GroceryStores GetGroceryStoreById(long id)
        {
            GroceryStores? store = groceryStores.Find(g => g.Id == id);
            ArgumentNullException.ThrowIfNull(store);
            return store;
        }
        public void UpdateGroceryStore(GroceryStoreDetails updateGroceryStore)
        {
            var existingGrocery = GetGroceryStoreById(updateGroceryStore.Id);

            existingGrocery.Name = updateGroceryStore.Name;
            existingGrocery.Status = updateGroceryStore.Status;
            existingGrocery.UpdatedOn = DateTime.Now;
        }

        public void DeleteGroceryStore(long id)
        {
            var store = GetGroceryStoreById(id);
            groceryStores.Remove(store);
        }
    }
}
