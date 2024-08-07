using BlazorProj.Models;

namespace BlazorProj.Clients.Families
{
    public class RelationService
    {
        private readonly Relation[] relations =
        [
            new(){
                Id = 1,
                Name = "Father"
            },
            new(){
                Id = 2,
                Name = "Mother"
            },
            new(){
                Id= 3,
                Name = "Son"
            },
            new(){
                Id = 4,
                Name = "Daughter"
            }

        ];

        public Relation[] GetRelations() => relations;
    }
}
