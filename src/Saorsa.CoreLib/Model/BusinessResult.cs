namespace Saorsa.Model;

public class BusinessResult<TContext, TResult>
{
    public string RefId { get; set; } = Guid.NewGuid().ToString("N");

    public TContext? Context { get; set; }
    
    public TResult? Result { get; set; }
    
    public BusinessError? Error { get; set; }

    public bool IsError => Error != null;

    public bool IsNull => Result == null;

    public ICollection<string> Messages { get; } = new List<string>();

    public IDictionary<string, object> ExtendedInfo { get; } = new Dictionary<string, object>();

    public static BusinessResult<TContext, TResult> Fail(
        BusinessError error,
        TContext? context = default)
    {
        return new BusinessResult<TContext, TResult>
        {
            Error = error,
            Context = context
        };
    }

    public static BusinessResult<TContext, TResult> Success(
        TResult? result,
        TContext? context = default)
    {
        return new BusinessResult<TContext, TResult>
        {
            Result = result,
            Context = context
        };
    }
}

public class BusinessResult<TResult> : BusinessResult<object, TResult>
{
}
