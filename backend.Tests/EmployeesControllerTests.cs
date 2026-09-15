using Api.Controllers;
using Api.Data;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class EmployeesControllerTests
{
    private static EmployeesController CreateController(
        out EmployeeStore employees, out SiteStore sites, out RoleStore roles)
    {
        employees = new EmployeeStore();
        sites = new SiteStore();
        roles = new RoleStore();
        return new EmployeesController(employees, sites, roles);
    }

    [Fact]
    public void Create_WithValidData_AddsEmployee()
    {
        var controller = CreateController(out var employees, out var sites, out var roles);
        var siteId = sites.GetAll()[0].Id;
        var roleId = roles.GetAll()[0].Id;

        var result = controller.Create(new EmployeeRequest { Name = "Jane Doe", SiteId = siteId, RoleId = roleId });

        var created = Assert.IsType<CreatedAtActionResult>(result.Result);
        var dto = Assert.IsType<EmployeeDto>(created.Value);
        Assert.Equal("Jane Doe", dto.Name);
        Assert.Single(employees.GetAll());
    }

    [Fact]
    public void Create_WithEmptyName_ReturnsValidationError()
    {
        var controller = CreateController(out var employees, out var sites, out var roles);
        controller.ModelState.AddModelError(nameof(EmployeeRequest.Name), "The Name field is required.");

        var result = controller.Create(new EmployeeRequest { Name = "", SiteId = sites.GetAll()[0].Id, RoleId = roles.GetAll()[0].Id });

        Assert.IsType<ObjectResult>(result.Result);
        Assert.Empty(employees.GetAll());
    }

    [Fact]
    public void Create_WithUnknownSite_ReturnsValidationError()
    {
        var controller = CreateController(out var employees, out var sites, out var roles);

        var result = controller.Create(new EmployeeRequest { Name = "Jane Doe", SiteId = 9999, RoleId = roles.GetAll()[0].Id });

        Assert.IsType<ObjectResult>(result.Result);
        Assert.Empty(employees.GetAll());
    }

    [Fact]
    public void Create_WithUnknownRole_ReturnsValidationError()
    {
        var controller = CreateController(out var employees, out var sites, out var roles);

        var result = controller.Create(new EmployeeRequest { Name = "Jane Doe", SiteId = sites.GetAll()[0].Id, RoleId = 9999 });

        Assert.IsType<ObjectResult>(result.Result);
        Assert.Empty(employees.GetAll());
    }

    [Fact]
    public void Update_WithValidData_UpdatesNameSiteAndRole()
    {
        var controller = CreateController(out var employees, out var sites, out var roles);
        var original = employees.Add("Jane Doe", sites.GetAll()[0].Id, roles.GetAll()[0].Id);
        var newSiteId = sites.GetAll()[1].Id;
        var newRoleId = roles.GetAll()[1].Id;

        var result = controller.Update(original.Id, new EmployeeRequest { Name = "Jane Smith", SiteId = newSiteId, RoleId = newRoleId });

        var ok = Assert.IsType<OkObjectResult>(result.Result);
        var dto = Assert.IsType<EmployeeDto>(ok.Value);
        Assert.Equal("Jane Smith", dto.Name);
        Assert.Equal(newSiteId, dto.SiteId);
        Assert.Equal(newRoleId, dto.RoleId);
    }

    [Fact]
    public void Update_DoesNotAffectOtherEmployees()
    {
        var controller = CreateController(out var employees, out var sites, out var roles);
        var siteId = sites.GetAll()[0].Id;
        var roleId = roles.GetAll()[0].Id;
        var target = employees.Add("Jane Doe", siteId, roleId);
        var other = employees.Add("John Roe", siteId, roleId);

        controller.Update(target.Id, new EmployeeRequest { Name = "Jane Smith", SiteId = siteId, RoleId = roleId });

        var untouched = employees.GetById(other.Id);
        Assert.Equal("John Roe", untouched!.Name);
    }

    [Fact]
    public void Update_UnknownEmployee_ReturnsNotFound()
    {
        var controller = CreateController(out var employees, out var sites, out var roles);

        var result = controller.Update(9999, new EmployeeRequest { Name = "Jane Doe", SiteId = sites.GetAll()[0].Id, RoleId = roles.GetAll()[0].Id });

        Assert.IsType<NotFoundResult>(result.Result);
    }
}
