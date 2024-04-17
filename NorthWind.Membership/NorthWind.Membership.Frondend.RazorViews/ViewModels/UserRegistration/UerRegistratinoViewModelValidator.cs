namespace NorthWind.Membership.Frondend.RazorViews.ViewModels.UserRegistration;
internal class UerRegistratinoViewModelValidator : AbstractModelValidator<UserRegistrationViewModel>
{
    public UerRegistratinoViewModelValidator(IValidationService<UserRegistrationViewModel> validationService) :
        base(validationService, ValidationConstraint.AlwaysValidate)
    {
        AddRuleFor(u => u.PasswordConfirmation)
            .Equal(u=> u.Password, UserRegistrationMessages.ConfirmPasswordErrorMessage);
    }
}
