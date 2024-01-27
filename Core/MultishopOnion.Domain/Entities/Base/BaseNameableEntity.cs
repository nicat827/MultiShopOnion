namespace MultishopOnion.Domain.Entities.Base
{
    internal class BaseNameableEntity:BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
