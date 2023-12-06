namespace Saorsa.Model;


/// <summary>
/// Represents a DTO filter output for a business operation.
/// </summary>
/// <typeparam name="TContext">The context of the business result.</typeparam>
/// <typeparam name="TResult">The type of the objects being returned by the business operation.</typeparam>
public class BusinessResult<TContext, TResult>
{
    /// <summary>
    /// Gets or sets the reference identifier of the result.
    /// </summary>
    public string RefId { get; set; } = Guid.NewGuid().ToString("N");

    /// <summary>
    /// Gets or sets the context of the business operation result.
    /// </summary>
    public TContext? Context { get; set; }

    /// <summary>
    /// Gets or sets the actual result value.
    /// </summary>
    public TResult? Result { get; set; }

    /// <summary>
    /// Gets or sets the business error that occurred while processing the result.
    /// </summary>
    public BusinessError? Error { get; set; }

    /// <summary>
    /// Gets a value indicating whether this result is a fault or not.
    /// </summary>
    public bool IsError => Error != null;

    /// <summary>
    /// Gets a value indicating whether this result is NULL. 
    /// </summary>
    public bool IsNull => Result == null;

    /// <summary>
    /// Gets the sequence of information messages associated with the result.
    /// </summary>
    public ICollection<string> Messages { get; } = new List<string>();

    /// <summary>
    /// Gets the sequence of warning messages associated with the result.
    /// </summary>
    public ICollection<string> Warnings { get; } = new List<string>();

    /// <summary>
    /// Gets the sequence of error messages associated with the result.
    /// </summary>
    public ICollection<string> Errors { get; } = new List<string>();

    /// <summary>
    /// Gets a meta data container for the result.
    /// </summary>
    public IDictionary<string, object> ExtendedInfo { get; } = new Dictionary<string, object>();


    /// <summary>
    /// Creates an error result / fault.
    /// </summary>
    /// <param name="error">The business error.</param>
    /// <param name="context">The context of the operation.</param>
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

    /// <summary>
    /// Creates a success result.
    /// </summary>
    /// <param name="result">The result value.</param>
    /// <param name="context">The context of the operation.</param>
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


/// <summary>
/// Represents a DTO filter output for a business operation.
/// </summary>
/// <typeparam name="TResult">The type of the objects being returned by the business operation.</typeparam>
public class BusinessResult<TResult> : BusinessResult<object, TResult>
{
}
