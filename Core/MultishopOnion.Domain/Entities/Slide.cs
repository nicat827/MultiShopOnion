using MultishopOnion.Domain.Entities.Base;
namespace MultishopOnion.Domain.Entities
{
    public class Slide:BaseNameableEntity
    {
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = null!;

        public string ButtonText { get; set; } = "Shop Now!";
        public int Order { get; set; }

    }
}
