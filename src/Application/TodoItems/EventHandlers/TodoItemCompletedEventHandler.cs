using some_app.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace some_app.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("some_app Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
