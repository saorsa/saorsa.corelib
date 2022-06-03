using System.Runtime.Serialization;

namespace Saorsa;

public class KeyException<TKey> : Exception
    where TKey: IComparable<TKey>
{
    public TKey Key { get; }

    public KeyException(TKey key, string? message) : base(message)
    {
        Key = key;
    }

    public KeyException(TKey key, string? message, Exception? inner) : base(message, inner)
    {
        Key = key;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);

        info.AddValue(nameof(Key), Key.ToString(), typeof(string));
    }
}

public class KeyException : KeyException<Guid>
{
    public KeyException(Guid key, string? message) : base(key, message)
    {
    }

    public KeyException(Guid key, string? message, Exception? inner) : base(key, message, inner)
    {
    }
}
