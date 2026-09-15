using System.ComponentModel.DataAnnotations;

namespace Api.Dtos;

public class EmployeeRequest
{
    [Required(AllowEmptyStrings = false)]
    public required string Name { get; set; }

    public int SiteId { get; set; }

    public int RoleId { get; set; }
}
