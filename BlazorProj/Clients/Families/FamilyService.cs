using BlazorProj.Clients.GroceryStore;
using BlazorProj.Clients.Programs;
using BlazorProj.Models;

namespace BlazorProj.Clients.Families
{
    public class FamilyService
    {
        private readonly List<Family> families =
        [
            new(){
                FamilyHeadId = 1,
                Name = "Marcus",
                Age = 20,
                Gender = "Male",
                Relation = "Son",
                Description = "It is a long established fact that a reader will be distracted by layout."
            }
        ];
        public Family[] GetFamily() => [.. families];

        private readonly Relation[] relations = new RelationService().GetRelations();

        private readonly Campaign[] campaigns = new CampaignClients().GetCampaigns();
        private readonly GroceryStores[] groceryStores = new GroceryStoreClients().GetGroceryStore();
        private readonly Programm[] programms = new ProgramClients().GetProgram();
        public void AddMember(FamilyDetails familyDetails)
        {
            var relation = GetRelationById(familyDetails.RelationId);
            var family = new Family
            {
                FamilyHeadId = families.Count + 1,
                Name = familyDetails.Name,
                Age = familyDetails.Age,
                Gender = familyDetails.Gender,
                Relation = relation.Name,
                Description = familyDetails.Description
            };
            families.Add(family);
        }

        public FamilyDetails GetFamily(long id)
        {
            Family family = GetFamilyById(id);
            var relation = relations.FirstOrDefault(relation => string.Equals(relation.Name,family.Relation, StringComparison.OrdinalIgnoreCase));
            return new FamilyDetails
            {
                FamilyHeadId = family.FamilyHeadId,
                Name = family.Name,
                Age = family.Age,
                Gender = family.Gender,
                RelationId = relation.Id.ToString(),
                Description = family.Description
            };
        }
        private Family GetFamilyById(long id)
        {
            Family? family = families.Find(family => family.FamilyHeadId == id);
            ArgumentNullException.ThrowIfNull(family);
            return family;
        }
        public void UpdateFamily(FamilyDetails familyDetails)
        {
            var relation = GetRelationById(familyDetails.RelationId);
            var existingFamily = GetFamilyById(familyDetails.FamilyHeadId);

            existingFamily.Name = familyDetails.Name;
            existingFamily.Age = familyDetails.Age;
            existingFamily.Gender = familyDetails.Gender;
            existingFamily.Relation = relation.Name;
            existingFamily.Description = familyDetails.Description;
        }

        public void DeleteFamily(long id)
        {
            var family = GetFamilyById(id);
            families.Remove(family);
        }

        private Relation GetRelationById(string? id)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(id);
            return relations.Single(relations => relations.Id == int.Parse(id));
        } 
        
        
    }
}
