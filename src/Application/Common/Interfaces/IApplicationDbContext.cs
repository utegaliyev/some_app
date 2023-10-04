using some_app.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace some_app.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Country> Countries { get; }

    DbSet<Province> Provinces { get; }

    DbSet<PersonalInfo> PersonalInfos { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
