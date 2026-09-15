namespace Api.Models;

public class Employee
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int SiteId { get; set; }

    public int RoleId { get; set; }
}
