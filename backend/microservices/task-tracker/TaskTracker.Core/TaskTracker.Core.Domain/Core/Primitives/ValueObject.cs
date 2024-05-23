namespace TaskTracker.Core.Domain.Core.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? a, ValueObject? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }
    
    public static bool operator !=(ValueObject? a, ValueObject? b)
    {
        return !(a == b);
    }
    
    public bool Equals(ValueObject? other)
    {
        return !(other is null) && GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (GetType() != obj.GetType())
        {
            return false;
        }

        if (obj is not ValueObject valueObject)
        {
            return false;
        }

        return GetAtomicValues().SequenceEqual(valueObject.GetAtomicValues());
    }

    public override int GetHashCode()
    {
        HashCode hashCode = default;

        foreach (var obj in GetAtomicValues())
        {
            hashCode.Add(obj);
        }
 
        return hashCode.ToHashCode();
    }

    protected abstract IEnumerable<object> GetAtomicValues();
}