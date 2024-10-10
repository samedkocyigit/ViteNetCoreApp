using ViteNetCoreApp.Domain.Models.Models;

namespace ViteNetCoreApp.Domain.Models.DTOs
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int UserId {  get; set; }
        public TaskState? State { get; set; }
    }
}
