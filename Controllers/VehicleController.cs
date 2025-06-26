using Microsoft.AspNetCore.Mvc;
using CarInfoAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class VehicleController : ControllerBase
{
    private readonly IVehicleApiService _vehicleService;

    public VehicleController(IVehicleApiService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet("makes")]
    public async Task<ActionResult<List<Make>>> GetMakes()
    {
        var makes = await _vehicleService.GetAllMakesAsync();
        return Ok(makes);
    }

    [HttpGet("vehicle-types/{makeId}")]
    public async Task<ActionResult<List<VehicleType>>> GetVehicleTypes(int makeId)
    {
        var types = await _vehicleService.GetVehicleTypesForMakeIdAsync(makeId);
        return Ok(types);
    }

    [HttpGet("models")]
    public async Task<ActionResult<List<CarModel>>> GetModels([FromQuery] int makeId, [FromQuery] int year, [FromQuery] string vehicleType)
    {
        var models = await _vehicleService.GetModelsAsync(makeId, year, vehicleType);
        return Ok(models);
    }
}
