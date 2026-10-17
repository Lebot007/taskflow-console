# TaskFlow

TaskFlow é um gerenciador de tarefas em console, desenvolvido com .NET 10 e testes unitários com xUnit.

## Requisitos

- .NET 10 SDK
- Git

## Como compilar

```bash
dotnet restore
dotnet build TaskFlow.slnx
```

## Como executar a aplicação

```bash
dotnet run --project TaskFlow.Console/TaskFlow.Console.csproj
```

## Como executar os testes

```bash
dotnet test TaskFlow.slnx
```

## Funcionalidades

- Adicionar tarefas
- Listar tarefas
- Concluir tarefas
- Buscar tarefa por ID

## Fluxo de desenvolvimento

O projeto foi estruturado em commits seguindo o padrão Conventional Commits, com domínio, serviços, testes, correção de bugs, refatoração e documentação.
