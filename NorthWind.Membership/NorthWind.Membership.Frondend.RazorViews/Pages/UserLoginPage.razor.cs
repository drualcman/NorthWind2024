namespace NorthWind.Membership.Frondend.RazorViews.Pages;
public partial class UserLoginPage
{
    const string RouteTemplate = "/user/login";
    [Inject] UserLoginViewModel ViewModel { get; set; }
    [Inject] NavigationManager NavigationManager { get; set; }

    ErrorBoundary ErrorBoundoryRef;

    void Recover()
    {
        ErrorBoundoryRef?.Recover();
    }

    protected override void OnInitialized()
    {
        ViewModel.OnLogin += OnLogin;
    }

    void OnLogin()
    {
        if(NavigationManager.Uri.EndsWith(RouteTemplate, StringComparison.OrdinalIgnoreCase))
        {
            NavigationManager.NavigateTo("");
        }
        else
        {
            NavigationManager.NavigateTo(NavigationManager.Uri);
        }
    }
}