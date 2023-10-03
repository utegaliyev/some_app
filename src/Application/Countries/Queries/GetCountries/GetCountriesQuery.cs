using MediatR;
using Microsoft.EntityFrameworkCore;
using some_app.Application.Common.Interfaces;

namespace some_app.Application.Countries.Queries.GetCountries;

public class GetCountriesQuery : IRequest<IEnumerable<CountryDto>>
{
    
}

public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IEnumerable<CountryDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetCountriesQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Countries
            .Select(i => new CountryDto()
            {
                Id = i.Id,
                Name = i.Name,
            }).ToArrayAsync(cancellationToken);
    }
}