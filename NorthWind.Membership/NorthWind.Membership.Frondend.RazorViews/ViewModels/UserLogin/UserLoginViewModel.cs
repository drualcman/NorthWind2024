namespace NorthWind.Membership.Frondend.RazorViews.ViewModels.UserLogin;
public class UserLoginViewModel(MembershipGateway Gateway, IModelValidatorHub<UserLoginViewModel> ValidatorHub)
{
    public IModelValidatorHub<UserLoginViewModel> Validator => ValidatorHub;
    public ModelValidator<UserLoginViewModel> ModelValidatorComponentReference { get;set; }

    public event Action OnLogin;
    public string Email {  get; set; }  
    public string Password { get; set; }

    public async Task Login()
    {
        try
        {
            TokensDto tokens = await Gateway.LoginAsync((UserCredentialsDto)this);
            Console.WriteLine(tokens.AccessToken);
            OnLogin.Invoke();
        }
        catch (HttpRequestException ex)
        {
            if (ex.Data.Contains("Errors"))
            {
                IEnumerable<ValidationError> errors = ex.Data["Errors"] as IEnumerable<ValidationError>;
                ModelValidatorComponentReference.AddErrors(errors);
            }
            else
                throw;
        }
    }

    public static explicit operator UserCredentialsDto(UserLoginViewModel model) =>
        new UserCredentialsDto(model.Email, model.Password);
}
