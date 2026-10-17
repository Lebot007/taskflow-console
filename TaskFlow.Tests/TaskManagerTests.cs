using TaskFlow.Console;

namespace TaskFlow.Tests;

public class TaskManagerTests
{
    [Fact]
    public void AddTask_ShouldStoreTaskInMemory()
    {
        var manager = new TaskManager();

        var task = manager.AddTask("Estudar para a prova");

        Assert.Single(manager.GetAllTasks());
        Assert.Equal("Estudar para a prova", task.Title);
        Assert.False(task.IsCompleted);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void AddTask_ShouldRejectEmptyOrWhitespaceTitles(string? title)
    {
        var manager = new TaskManager();

        Assert.Throws<ArgumentException>(() => manager.AddTask(title!));
    }

    [Fact]
    public void CompleteTask_ShouldToggleCompletionStatus()
    {
        var manager = new TaskManager();
        var task = manager.AddTask("Revisar o código");

        manager.CompleteTask(task.Id);

        Assert.True(task.IsCompleted);
    }

    [Fact]
    public void GetTaskById_ShouldReturnNullWhenTaskDoesNotExist()
    {
        var manager = new TaskManager();

        var task = manager.GetTaskById(Guid.NewGuid());

        Assert.Null(task);
    }
}
