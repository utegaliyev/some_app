using AutoMapper;
using AutoMapper.QueryableExtensions;
using some_app.Application.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace some_app.Application.Common.Mappings;

public static class MappingExtensions
{
    public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
}
