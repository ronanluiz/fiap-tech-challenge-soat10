namespace Soat10.TechChallenge.Domain.Base
{
    public abstract class AuditableEntity<TId> : Entity<TId> where TId : notnull
    {
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? UserUpdated { get; private set; }

        protected AuditableEntity() : base()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        protected AuditableEntity(TId id) : base(id)
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateAuditInfo(string user)
        {
            UpdatedAt = DateTime.UtcNow;
            UserUpdated = user;
        }
    }
}
