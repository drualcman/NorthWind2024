using Microsoft.AspNetCore.Components;

namespace NorthWind.Razor.Components.NavBars;
public partial class NavMenu
{
    [Parameter] public RenderFragment NavBarBrand { get; set; }
    [Parameter] public RenderFragment NavBarItems { get; set; }

    bool CollapseNaveMenu = true;
    string NavMenuCssClass => CollapseNaveMenu ? "collapse" : null;

    void ToggleNavMenu()
    {
        CollapseNaveMenu = !CollapseNaveMenu;
    }
}
