namespace Saorsa;

public class KeyNotFoundException<TKey>: KeyException<TKey>
    where TKey: IComparable<TKey>
{
    public KeyNotFoundException(TKey key, string? message) : base(key, message)
    {
    }

    public KeyNotFoundException(TKey key, string? message, Exception? inner) : base(key, message, inner)
    {
    }
}

public class KeyNotFoundException : KeyNotFoundException<Guid>
{
    public KeyNotFoundException(Guid key, string? message) : base(key, message)
    {
    }

    public KeyNotFoundException(Guid key, string? message, Exception? inner) : base(key, message, inner)
    {
    }
}
