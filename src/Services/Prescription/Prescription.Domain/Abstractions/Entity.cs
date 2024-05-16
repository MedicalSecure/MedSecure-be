namespace Prescription.Domain.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        public T Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }

        /*        public override bool Equals(object? obj)
                {
                    if (ReferenceEquals(this, obj)) return true;
                    if (obj is null || GetType() != obj.GetType()) return false;
                    return Equals((Entity<T>)obj);
                }

                public virtual bool Equals(Entity<T> other)
                {
                    return EqualityComparer<T>.Default.Equals(Id, other.Id);
                }

                public override int GetHashCode()
                {
                    return EqualityComparer<T>.Default.GetHashCode(Id);
                }

                public static bool operator ==(Entity<T> left, Entity<T> right)
                {
                    if (ReferenceEquals(right, null) && ReferenceEquals(left, null)) return true;
                    if (ReferenceEquals(right, null) || ReferenceEquals(left, null)) return false;

                    Console.WriteLine("test");
                    return EqualityComparer<T>.Default.Equals(left.Id, right.Id);
                }

                public static bool operator !=(Entity<T> left, Entity<T> right)
                {
                    return !(left == right);
                }*/
    }
}