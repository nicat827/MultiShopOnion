namespace MultishopOnion.Domain.Entities.Base
{
    internal abstract class BaseNameableEntity:BaseEntity
    {
        public string Name { get; set; } = null!;
    }
}
