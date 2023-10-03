using MediatR;
using some_app.Application.Common.Exceptions;
using some_app.Application.Common.Interfaces;
using some_app.Domain.Entities;

namespace some_app.Application.PersonalInfos.Commands;

public class RegisterPersonalInfoCommand : IRequest<string>
{
    public string Login { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public bool isAgreed { get; set; }

    public int ProvinceId { get; set; }
}

public class RegisterPersonalInfoCommandHandler : IRequestHandler<RegisterPersonalInfoCommand, string>
{
    private readonly IIdentityService _identityService;
    private readonly IApplicationDbContext _applicationDbContext;


    public RegisterPersonalInfoCommandHandler(IIdentityService identityService, IApplicationDbContext applicationDbContext)
    {
        _identityService = identityService;
        _applicationDbContext = applicationDbContext;
    }

    public async Task<string> Handle(RegisterPersonalInfoCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateUserAsync(request.Login, request.Password);
        
        var province = await _applicationDbContext.Provinces.FindAsync(new object[]{request.ProvinceId}, cancellationToken)
                       ?? throw new NotFoundException("Province not found");
        
        var personalInfo = new PersonalInfo{Id = Guid.Parse(result.UserId), Province = province};
        
        await _applicationDbContext.PersonalInfos.AddAsync(personalInfo, cancellationToken);
        
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return result.UserId;
    }
}