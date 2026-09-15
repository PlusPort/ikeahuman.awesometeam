using Api.Models;

namespace Api.Data;

/// <summary>In-memory Employee store, per the team's no-persistence decision.</summary>
public class EmployeeStore
{
    private readonly List<Employee> _employees = [];
    private int _nextId = 1;

    public IReadOnlyList<Employee> GetAll() => _employees;

    public Employee? GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

    public Employee Add(string name, int siteId, int roleId)
    {
        var employee = new Employee { Id = _nextId++, Name = name, SiteId = siteId, RoleId = roleId };
        _employees.Add(employee);
        return employee;
    }

    public void Update(Employee employee)
    {
        var index = _employees.FindIndex(e => e.Id == employee.Id);
        _employees[index] = employee;
    }
}
