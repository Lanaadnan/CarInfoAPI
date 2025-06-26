using System.Collections.Generic;
using System.Threading.Tasks;
using CarInfoAPI.Models;

public interface IVehicleApiService
{
    Task<List<Make>> GetAllMakesAsync();
    Task<List<VehicleType>> GetVehicleTypesForMakeIdAsync(int makeId);
    Task<List<CarModel>> GetModelsAsync(int makeId, int year, string vehicleType);
}
