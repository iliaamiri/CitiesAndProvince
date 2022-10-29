using CitiesAndProvince.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitiesAndProvince.Controllers;

[ApiController]
[Route("[controller]")]
public class ProvinceController : ControllerBase
{
    private readonly ILogger<ProvinceController> _logger;
    private readonly CitiesProvinceDbContext _db;

    public ProvinceController(
        ILogger<ProvinceController> logger,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _db = new CitiesProvinceDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<CitiesProvinceDbContext>>()
        );
    }

    [HttpGet]
    public async Task<ActionResult> Index()
    {
        return await Task.Run<ActionResult>(() =>
        {
            try
            {
                return Ok(_db.Provinces);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        });
    }
}