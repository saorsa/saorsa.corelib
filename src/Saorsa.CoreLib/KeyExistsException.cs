namespace Saorsa;

public class KeyExistsException<TKey> : KeyException<TKey>
    where TKey: IComparable<TKey>
{
    public KeyExistsException(TKey key, string? message) : base(key, message)
    {
    }

    public KeyExistsException(TKey key, string? message, Exception? inner) : base(key, message, inner)
    {
    }
}

public class KeyExistsException : KeyExistsException<Guid>
{
    public KeyExistsException(Guid key, string? message) : base(key, message)
    {
    }

    public KeyExistsException(Guid key, string? message, Exception? inner) : base(key, message, inner)
    {
    }
}
