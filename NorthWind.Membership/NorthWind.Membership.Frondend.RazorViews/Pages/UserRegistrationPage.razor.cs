namespace NorthWind.Membership.Frondend.RazorViews.Pages;
public partial class UserRegistrationPage
{
    [Inject] UserRegistrationViewModel ViewModel { get; set; }

    ErrorBoundary ErrorBoundoryRef;

    void Recover()
    {
        ErrorBoundoryRef?.Recover();
    }
}