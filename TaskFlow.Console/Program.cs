using TaskFlow.Console;

var taskManager = new TaskManager();
var isInteractive = !Console.IsInputRedirected && !Console.IsOutputRedirected;

while (true)
{
    if (isInteractive)
    {
        Console.Clear();
    }

    Console.WriteLine("=== TaskFlow ===");
    Console.WriteLine("1 - Adicionar tarefa");
    Console.WriteLine("2 - Listar tarefas");
    Console.WriteLine("3 - Concluir tarefa");
    Console.WriteLine("4 - Buscar tarefa por ID");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    var option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Write("Digite o título da tarefa: ");
            var title = Console.ReadLine();

            try
            {
                var task = taskManager.AddTask(title ?? string.Empty);
                Console.WriteLine($"Tarefa adicionada com sucesso: {task.Title}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Pause();
            break;

        case "2":
            ListTasks(taskManager);
            Pause();
            break;

        case "3":
            Console.Write("Digite o ID da tarefa: ");
            var completionId = Console.ReadLine();

            if (Guid.TryParse(completionId, out var completeGuid))
            {
                try
                {
                    var task = taskManager.CompleteTask(completeGuid);
                    Console.WriteLine($"Status atualizado: {task.Title} -> {(task.IsCompleted ? "Concluída" : "Pendente")}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Tarefa não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }

            Pause();
            break;

        case "4":
            Console.Write("Digite o ID da tarefa: ");
            var searchId = Console.ReadLine();

            if (Guid.TryParse(searchId, out var searchGuid))
            {
                var task = taskManager.GetTaskById(searchGuid);

                if (task is null)
                {
                    Console.WriteLine("Tarefa não encontrada.");
                }
                else
                {
                    Console.WriteLine($"ID: {task.Id}");
                    Console.WriteLine($"Título: {task.Title}");
                    Console.WriteLine($"Status: {(task.IsCompleted ? "Concluída" : "Pendente")}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }

            Pause();
            break;

        case "0":
            Console.WriteLine("Até logo!");
            return;

        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            Pause();
            break;
    }
}

static void ListTasks(TaskManager taskManager)
{
    var tasks = taskManager.GetAllTasks();

    if (tasks.Count == 0)
    {
        Console.WriteLine("Nenhuma tarefa cadastrada.");
        return;
    }

    Console.WriteLine("Tarefas:");
    foreach (var task in tasks)
    {
        Console.WriteLine($"- {task.Id} | {task.Title} | {(task.IsCompleted ? "Concluída" : "Pendente")}");
    }
}

static void Pause()
{
    Console.WriteLine();

    if (!Console.IsInputRedirected && !Console.IsOutputRedirected)
    {
        Console.Write("Pressione Enter para continuar...");
        Console.ReadLine();
    }
}
