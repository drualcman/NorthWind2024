namespace NorthWind.UserServices;

internal class UserService(IHttpContextAccessor ContextAccessor) : IUserService
{
    public bool IsAuthenticated => ContextAccessor.HttpContext.User.Identity.IsAuthenticated;

    public string UserName => ContextAccessor.HttpContext.User.Identity.Name;

    public string FullName => ContextAccessor.HttpContext.User.Claims
        .Where(c => c.Type == "FullName")
        .Select(c => c.Value)
        .FirstOrDefault();
}
