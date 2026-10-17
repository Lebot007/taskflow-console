namespace TaskFlow.Console;

public class TaskItem
{
    public Guid Id { get; }
    public string Title { get; private set; }
    public bool IsCompleted { get; private set; }

    public TaskItem(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Task title cannot be empty.", nameof(title));
        }

        Id = Guid.NewGuid();
        Title = title.Trim();
        IsCompleted = false;
    }

    public void ToggleCompletion()
    {
        IsCompleted = !IsCompleted;
    }
}
