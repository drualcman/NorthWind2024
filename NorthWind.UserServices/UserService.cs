using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace NorthWind.UserServices;

internal class UserService : IUserService
{
    public bool IsAuthenticated { get; private set; }

    public string UserName { get; private set; }

    public string FullName { get; private set; }

    public UserService(IHttpContextAccessor contextAccessor)
    {
        HttpContext context = contextAccessor.HttpContext;
        if(context.Request.Headers.TryGetValue("", out StringValues value))
        {
            IsAuthenticated = true;
            UserName = value;
        }
    }
}
