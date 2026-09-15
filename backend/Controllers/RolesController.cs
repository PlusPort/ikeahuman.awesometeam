using Api.Data;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{
    private readonly RoleStore _roles;

    public RolesController(RoleStore roles)
    {
        _roles = roles;
    }

    [HttpGet]
    public ActionResult<IEnumerable<LookupDto>> GetAll()
    {
        return Ok(_roles.GetAll().Select(r => new LookupDto(r.Id, r.Name)));
    }
}
