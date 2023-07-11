using Microsoft.Extensions.Logging;
using ToDoApplication.DAL.Interfaces;
using ToDoApplication.Domain.Entity;
using ToDoApplication.Domain.Enum;
using ToDoApplication.Domain.Response;
using ToDoApplication.Domain.ViewModels.Task;
using ToDoApplication.Service.Interfaces;

namespace ToDoApplication.Service.Implementations;

public class TaskService : ITaskService
{
    private readonly IBaseRepository<TaskEntity> _taskRepository;
    private ILogger<TaskService>? _logger;

    public TaskService(IBaseRepository<TaskEntity> taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<IBaseResponse<TaskEntity>> Create(CreateTaskViewModel model)
    {
        try
        {
            _logger.LogInformation($"Request to creating TASK - {model.Name}");

            var task = _taskRepository.GetAll()
                .Where(x => x.Created.Date == DateTime.Today)
                .FirstOrDefault(x => x.Name == model.Name);
            if (task != null)
            {
                return new BaseResponse<TaskEntity>()
                {
                    Description = "Task with this name exists",
                    StatusCode = StatusCode.TaskIsHasAlready
                };
            }

            task = new TaskEntity()
            {
                Name = model.Name,
                Description = model.Description,
                Priority = model.Priority,
                Created = DateTime.Now
            };

            await _taskRepository.Create(task);
            
            _logger.LogInformation($"Task Created - {task.Name} {task.Created}");

            return new BaseResponse<TaskEntity>()
            {
                Description = "TASK CREATED",
                StatusCode = StatusCode.Created
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"[TaskService.Create]: {e.Message}");

            return new BaseResponse<TaskEntity>()
            {
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
}