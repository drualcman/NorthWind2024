namespace NorthWind.Membership.Backend.Core.UseCases;
internal class UserLoginInteractor(IMembershipService MembershipService, IUserLoginOutputPort OutputPort,
    IModelValidatorHub<UserCredentialsDto> ValidationService) : IUserLoginInputPort
{
    public async Task Handle(UserCredentialsDto userData)
    {
        Result<UserDto, IEnumerable<ValidationError>> result;

        if (await ValidationService.Validate(userData))
        {
            UserDto user = await MembershipService.GetUserByCredentials(userData);
            if (user == null)
            {
                result = new Result<UserDto, IEnumerable<ValidationError>>([
                        new ValidationError(nameof(userData.Password), UserLoginMessages.InvalidUserCredentialsErrorMessages)
                    ]);
            }
            else
            {
                result = new Result<UserDto, IEnumerable<ValidationError>>(user);
            }
        }
        else
        {
            result = new Result<UserDto, IEnumerable<ValidationError>>(ValidationService.Errors);
        }
        await OutputPort.Handle(result);
    }
}
