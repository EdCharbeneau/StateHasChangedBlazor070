using Microsoft.AspNetCore.Blazor;
using System;

namespace StateHasChangedBlazor070.Components.Tabs
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
        Enum Name { get; }
    }
}
