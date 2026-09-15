namespace Api.Models;

public class Role
{
    public int Id { get; set; }

    public required string Name { get; set; }

    /// <summary>Ids of the Course versions an Employee in this Role must complete.</summary>
    public List<int> RequiredCourseIds { get; set; } = [];
}
