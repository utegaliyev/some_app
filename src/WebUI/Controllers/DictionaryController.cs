using Microsoft.AspNetCore.Mvc;
using some_app.Application.Countries.Queries.GetCountries;
using some_app.Application.Provinces.Queries.GetProvinces;
using some_app.WebUI.Controllers;

namespace WebUI.Controllers;

public class DictionaryController : ApiControllerBase
{
    [HttpGet("Countries")]
    public async Task<IEnumerable<CountryDto>> GetCountries(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetCountriesQuery(), cancellationToken);
    }

    [HttpGet("Provinces")]
    public async Task<IEnumerable<ProvinceDto>> GetProvinces([FromQuery]GetProvincesQuery query, CancellationToken cancellationToken)
    {
        return await Mediator.Send(query, cancellationToken);
    }
}
