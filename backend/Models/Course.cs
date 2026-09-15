namespace Api.Models;

public class Course
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int Version { get; set; }

    public bool IsActive { get; set; } = true;

    /// <summary>Id of the Course version this one retires/replaces, if any.</summary>
    public int? SupersedesCourseId { get; set; }
}
