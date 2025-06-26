namespace CarInfoAPI.Models
{
    public class ApiResponseWrapper<T>
    {
        public int Count { get; set; }
        public List<T> Results { get; set; }
    }
}
