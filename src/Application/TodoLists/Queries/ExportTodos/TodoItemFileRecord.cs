using some_app.Application.Common.Mappings;
using some_app.Domain.Entities;

namespace some_app.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; init; }

    public bool Done { get; init; }
}
