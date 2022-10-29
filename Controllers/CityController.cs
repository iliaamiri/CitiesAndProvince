using CitiesAndProvince.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CitiesAndProvince.Controllers;

public class CityController : ControllerBase
{
    private readonly ILogger<CityController> _logger;
    private readonly CitiesProvinceDbContext _db;

    public CityController(
        ILogger<CityController> logger,
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
                return Ok(_db.Cities);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        });
    }
}