namespace Saorsa.Model;

public class SortDescriptor
{
    public string Property { get; set; } = $"Property-{Guid.NewGuid()}";

    public bool? IsDescending { get; set; }
}
