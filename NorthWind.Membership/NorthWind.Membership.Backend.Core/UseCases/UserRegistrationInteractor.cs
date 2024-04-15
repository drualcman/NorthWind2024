namespace NorthWind.Membership.Backend.Core.UseCases;
internal class UserRegistrationInteractor(IMembershipService MembershipService,
    IUserRegistrationOutputPort Presenter, IModelValidatorHub<UserRegistrationDto> ValidationService) : IUserRegistrationInputPort
{
    public async Task Handle(UserRegistrationDto userData)
    {
        Result<IEnumerable<ValidationError>> result;
        if (await ValidationService.Validate(userData))
        {
            result = await MembershipService.Register(userData);
        }
        else
        {
            result = new(ValidationService.Errors);
        }
        await Presenter.Handle(result);
    }
}
