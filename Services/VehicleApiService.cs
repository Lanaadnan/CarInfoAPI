using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarInfoAPI.Models;
using CarInfoAPI.Models;

public class VehicleApiService : IVehicleApiService
{
    private readonly HttpClient _httpClient;

    public VehicleApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Make>> GetAllMakesAsync()
    {
        var url = "https://vpic.nhtsa.dot.gov/api/vehicles/getallmakes?format=json";
        var response = await _httpClient.GetFromJsonAsync<ApiResponseWrapper<Make>>(url);
        return response?.Results ?? new List<Make>();
    }

    public async Task<List<VehicleType>> GetVehicleTypesForMakeIdAsync(int makeId)
    {
        var url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetVehicleTypesForMakeId/{makeId}?format=json";
        var response = await _httpClient.GetFromJsonAsync<ApiResponseWrapper<VehicleType>>(url);
        return response?.Results ?? new List<VehicleType>();
    }

    public async Task<List<CarModel>> GetModelsAsync(int makeId, int year, string vehicleType)
    {
        var url = $"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json";
        var response = await _httpClient.GetFromJsonAsync<ApiResponseWrapper<CarModel>>(url);
        return response?.Results ?? new List<CarModel>();
    }
}
