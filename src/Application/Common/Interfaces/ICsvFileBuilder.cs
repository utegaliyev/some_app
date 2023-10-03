using some_app.Application.TodoLists.Queries.ExportTodos;

namespace some_app.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
