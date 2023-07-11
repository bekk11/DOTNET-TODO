using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Domain.ViewModels.Task;
using ToDoApplication.Service.Interfaces;

namespace ToDoApplication.Controllers;

public class TaskController : Controller
{
    private readonly ITaskService? _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskViewModel model)
    {
        var response = await _taskService.Create(model);
        if (response.StatusCode == Domain.Enum.StatusCode.Created)
        {
            return Ok(new { description = response.Description });
        }
        return BadRequest(new { description = response.Description });
    }
}