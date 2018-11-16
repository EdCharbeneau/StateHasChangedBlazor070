using Microsoft.AspNetCore.Blazor;

namespace StateHasChangedBlazor070.App.Shared.Tabs
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}
