namespace NorthWind.Membership.Frondend.RazorViews.ViewModels.UserRegistration;
internal class UserRegistrationViewModelDtoValidator(IModelValidatorHub<UserRegistrationDto> Validator) :
    AbstractViewModelValidator<UserRegistrationDto, UserRegistrationViewModel>(Validator, ValidationConstraint.AlwaysValidate)
{
}
