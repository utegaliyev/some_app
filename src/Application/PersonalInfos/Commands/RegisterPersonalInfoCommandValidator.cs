using FluentValidation;

namespace some_app.Application.PersonalInfos.Commands;

public class RegisterPersonalInfoCommandValidator  : AbstractValidator<RegisterPersonalInfoCommand>
{
    public RegisterPersonalInfoCommandValidator()
    {
        RuleFor(i => i.Login).NotEmpty();
        RuleFor(i => i.Password).NotEmpty();
        RuleFor(i => i.ConfirmPassword).NotEmpty().Equal(i => i.Password);
        RuleFor(i => i.ProvinceId).NotEmpty();
    }
}