using ToDoApplication.Domain.Entity;
using ToDoApplication.Domain.Response;
using ToDoApplication.Domain.ViewModels.Task;

namespace ToDoApplication.Service.Interfaces;

public interface ITaskService
{
    public Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model);
}