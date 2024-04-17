namespace NorthWind.Membership.Backend.AspNetIdentity.Services;
internal class MembershipService(UserManager<NothWindUser> manager) : IMembershipService
{
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
