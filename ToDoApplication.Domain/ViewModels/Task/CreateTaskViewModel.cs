﻿using ToDoApplication.Domain.Enum;

namespace ToDoApplication.Domain.ViewModels.Task;

public class CreateTaskViewModel
{
    public string Name { get; set; }

    public string Description { get; set; }
    
    public Priority Priority { get; set; }
}