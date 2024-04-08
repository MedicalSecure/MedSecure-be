namespace Prescription.Domain.Abstractions
{
    public abstract class EntityV2<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        protected EntityV2(bool createdNow = false, string? Creator = null)
        {
            if (createdNow)
            {
                CreatedAt = DateTime.Now;
                CreatedBy = Creator;
            }
        }

        protected EntityV2(T id, bool createdNow = false, string? Creator = null) : this(createdNow, Creator)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null || GetType() != obj.GetType()) return false;
            return Equals((EntityV2<T>)obj);
        }

        public virtual bool Equals(Entity<T> other)
        {
            return EqualityComparer<T>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Id);
        }

        public static bool operator ==(EntityV2<T> left, EntityV2<T> right)
        {
            return EqualityComparer<T>.Default.Equals(left.Id, right.Id);
        }

        public static bool operator !=(EntityV2<T> left, EntityV2<T> right)
        {
            return !(left == right);
        }
    }
}