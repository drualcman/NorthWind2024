namespace NorthWind.Membership.Frondend.RazorViews.ViewModels.UserRegistration;
public class UserRegistrationViewModel(MembershipGateway Gateway,
    IModelValidatorHub<UserRegistrationViewModel> ValidatorBk)
{
    public IModelValidatorHub<UserRegistrationViewModel> Validator => ValidatorBk;
    public ModelValidator<UserRegistrationViewModel> ModelValidatorComponentReference { get; set; }
    public string InformationMessage { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }

    public async Task Register()
    {
        try
        {
            InformationMessage = "";
            await Gateway.RegisterAsync((UserRegistrationDto)this);
            InformationMessage = UserRegistrationMessages.RegisteredUserMessage;
        }
        catch (HttpRequestException ex)
        {

            if (ex.Data.Contains("Errors"))
            {
                IEnumerable<ValidationError> errors = ex.Data["Errors"] as IEnumerable<ValidationError>;
                ModelValidatorComponentReference.AddErrors(errors);
            }
            else
            {
                throw;
            }
        }
    }

    public static explicit operator UserRegistrationDto(UserRegistrationViewModel model) =>
        new UserRegistrationDto(model.Email, model.Password, model.FirstName, model.LastName);
}
