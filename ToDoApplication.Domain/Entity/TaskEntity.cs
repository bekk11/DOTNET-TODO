using ToDoApplication.Domain.Enum;

namespace ToDoApplication.Domain.Entity;

public class TaskEntity
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime Created { get; set; }

    public Priority Priority { get; set; }
}