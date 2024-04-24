namespace NorthWind.Membership.Frondend.RazorViews.ViewModels.UserLogin;
internal class UserLoginViewModelDtoValidator(IModelValidatorHub<UserCredentialsDto> Validator) : 
    AbstractViewModelValidator<UserCredentialsDto, UserLoginViewModel>(Validator, ValidationConstraint.AlwaysValidate)    
{
}
