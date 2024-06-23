using NorthWind.Membership.Frondend.RazorViews.Extensions;
using System.Reflection;

namespace NorthWind.Sales.BlazorClient;
public partial class App
{
    Assembly[] AdditionalAssemblies => new Assembly[]
        {
    typeof(NorthWind.Sales.Frontend.Views.Pages.CreateOrder).Assembly,
    MembershipPages.Assembly
        };

}