using some_app.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace some_app.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("some_app Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
