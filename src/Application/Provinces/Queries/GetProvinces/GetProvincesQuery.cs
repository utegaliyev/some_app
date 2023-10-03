using MediatR;
using Microsoft.EntityFrameworkCore;
using some_app.Application.Common.Interfaces;

namespace some_app.Application.Provinces.Queries.GetProvinces;

public record GetProvincesQuery : IRequest<IEnumerable<ProvinceDto>>
{
    public int CountryId { get; set; }
};

public class GetProvincesQueryHandler : IRequestHandler<GetProvincesQuery, IEnumerable<ProvinceDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetProvincesQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<ProvinceDto>> Handle(GetProvincesQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Provinces
            .Where(i => request.CountryId == i.CountryId)
            .Select(i => new ProvinceDto()
            {
                Id = i.Id,
                Name = i.Name,
                CountryName = i.Country.Name
            }).ToArrayAsync(cancellationToken);
    }
}
