namespace TaskFlow.Console;

public class TaskManager
{
    private readonly List<TaskItem> _tasks = new();

    public IReadOnlyCollection<TaskItem> Tasks => _tasks.AsReadOnly();

    public TaskItem AddTask(string title)
    {
        var task = new TaskItem(title);
        _tasks.Add(task);
        return task;
    }

    public IReadOnlyList<TaskItem> GetAllTasks()
    {
        return _tasks.AsReadOnly();
    }

    public TaskItem? GetTaskById(Guid id)
    {
        return _tasks.FirstOrDefault(task => task.Id == id);
    }

    public TaskItem CompleteTask(Guid id)
    {
        var task = GetTaskById(id);

        if (task is null)
        {
            throw new KeyNotFoundException($"Task with id '{id}' was not found.");
        }

        task.ToggleCompletion();
        return task;
    }
}
