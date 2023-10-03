using some_app.Application.Common.Interfaces;

namespace some_app.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
