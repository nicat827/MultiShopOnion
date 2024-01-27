namespace MultishopOnion.Domain.Entities.Base
{
    internal abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set;}
        //public string CreatedById { get; set; } = null!;
        //public string? LastUpdatedById { get; set; }






    }
}
