namespace Saorsa.Model;


/// <summary>
/// Interface model for entities that can be identified by their unique identifier.
/// </summary>
/// <typeparam name="TId">
/// The underlying type of the unique identifier of the entity.
/// </typeparam>
public interface IIdentifiable<TId>
    where TId: IEquatable<TId>
{
    /// <summary>
    /// Gets or sets the unique ID of the entity.
    /// </summary>
    public TId Id { get; set; }
}
