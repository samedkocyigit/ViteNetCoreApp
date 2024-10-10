namespace ViteNetCoreApp.Domain.Models.DTOs
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }
        public required string Details { get; set; }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }

}
