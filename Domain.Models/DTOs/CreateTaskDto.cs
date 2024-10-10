namespace ViteNetCoreApp.Domain.Models.DTOs
{
    public class CreateTaskDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int UserId { get; set; }
    }
}
