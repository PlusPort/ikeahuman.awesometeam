using Api.Auth;
using Api.Data;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeStore _employees;
    private readonly SiteStore _sites;
    private readonly RoleStore _roles;

    public EmployeesController(EmployeeStore employees, SiteStore sites, RoleStore roles)
    {
        _employees = employees;
        _sites = sites;
        _roles = roles;
    }

    [HttpGet]
    public ActionResult<IEnumerable<EmployeeDto>> GetAll()
    {
        return Ok(_employees.GetAll().Select(ToDto));
    }

    [HttpGet("{id}")]
    public ActionResult<EmployeeDto> GetById(int id)
    {
        var employee = _employees.GetById(id);
        if (employee is null)
        {
            return NotFound();
        }

        return Ok(ToDto(employee));
    }

    [HttpPost]
    [AdminOnly]
    public ActionResult<EmployeeDto> Create(EmployeeRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        if (!_sites.Exists(request.SiteId))
        {
            ModelState.AddModelError(nameof(request.SiteId), "Site does not exist.");
        }

        if (!_roles.Exists(request.RoleId))
        {
            ModelState.AddModelError(nameof(request.RoleId), "Role does not exist.");
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var employee = _employees.Add(request.Name, request.SiteId, request.RoleId);
        return CreatedAtAction(nameof(GetById), new { id = employee.Id }, ToDto(employee));
    }

    [HttpPut("{id}")]
    [AdminOnly]
    public ActionResult<EmployeeDto> Update(int id, EmployeeRequest request)
    {
        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var employee = _employees.GetById(id);
        if (employee is null)
        {
            return NotFound();
        }

        if (!_sites.Exists(request.SiteId))
        {
            ModelState.AddModelError(nameof(request.SiteId), "Site does not exist.");
        }

        if (!_roles.Exists(request.RoleId))
        {
            ModelState.AddModelError(nameof(request.RoleId), "Role does not exist.");
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        employee.Name = request.Name;
        employee.SiteId = request.SiteId;
        employee.RoleId = request.RoleId;
        _employees.Update(employee);

        return Ok(ToDto(employee));
    }

    private static EmployeeDto ToDto(Api.Models.Employee employee) =>
        new(employee.Id, employee.Name, employee.SiteId, employee.RoleId);
}
