namespace Soat10.TechChallenge.Domain.Base
{
    public abstract class Entity<TId> where TId : notnull
    {
        public TId Id { get; protected set; }

        protected Entity()
        {
            Id = default!;
        }

        protected Entity(TId id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id), "Id não pode ser nulo.");
        }
    }
}
