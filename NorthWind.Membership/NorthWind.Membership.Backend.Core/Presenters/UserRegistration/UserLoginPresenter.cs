
namespace NorthWind.Membership.Backend.Core.Presenters.UserRegistration;
internal class UserLoginPresenter : IUserLoginOutputPort
{
    public IResult Result { get; private set; }

    public Task Handle(Result<UserDto, IEnumerable<ValidationError>> userLoginResult)
    {
        throw new NotImplementedException();
    }
}
