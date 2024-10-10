namespace ViteNetCoreApp.Domain.Models.Models
{

    public enum TaskState
    {
        Created,
        InProgress,
        Completed
    }
    public class Tasks
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public TaskState State { get; set; } = TaskState.Created;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
