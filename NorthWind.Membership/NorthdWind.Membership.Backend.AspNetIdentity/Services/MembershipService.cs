namespace NorthWind.Membership.Backend.AspNetIdentity.Services;
internal class MembershipService(UserManager<NothWindUser> manager) : IMembershipService
{
    public async Task<UserDto> GetUserByCredentials(UserCredentialsDto userData)
    {
        UserDto foundUser = null;

        NothWindUser user = await manager.FindByNameAsync(userData.Email);
        if (user != null && await manager.CheckPasswordAsync(user, userData.Password))
        {
            foundUser = new UserDto(user.UserName, user.FirstName, user.LastName);
        }

        return foundUser;
    }

    public async Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData)
    {
        Result<IEnumerable<ValidationError>> result;

        NothWindUser user = new NothWindUser
        {
            UserName = userData.Email,
            Email = userData.Email,
            FirstName = userData.FirstName,
            LastName = userData.LastName
        };

        var createResult = await manager.CreateAsync(user, userData.Password);

        if (createResult.Succeeded)
        {
            result = new Result<IEnumerable<ValidationError>>();
        }
        else
        {
            result = new Result<IEnumerable<ValidationError>>(createResult.Errors.ToValidationErrors());
        }
        return result;
    }
}
