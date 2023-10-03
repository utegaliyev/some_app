using Microsoft.AspNetCore.Mvc;
using some_app.Application.PersonalInfos.Commands;
using some_app.WebUI.Controllers;


public class PersonalInfoController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<string>> Create(RegisterPersonalInfoCommand command)
    {
        return await Mediator.Send(command);
    }
}