namespace Api.Models;

public class Certificate
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int CourseId { get; set; }

    public DateOnly IssuedDate { get; set; }

    public DateOnly ExpiryDate { get; set; }
}
