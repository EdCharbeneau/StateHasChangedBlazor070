using Microsoft.AspNetCore.Blazor;

namespace StateHasChangedBlazor070.Components.Tabs
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}
