using Api.Data;
using Api.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SitesController : ControllerBase
{
    private readonly SiteStore _sites;

    public SitesController(SiteStore sites)
    {
        _sites = sites;
    }

    [HttpGet]
    public ActionResult<IEnumerable<LookupDto>> GetAll()
    {
        return Ok(_sites.GetAll().Select(s => new LookupDto(s.Id, s.Name)));
    }
}
