using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;

namespace StateHasChangedBlazor070.Components.Tabs
{
    public class TabComponent : BlazorComponent, ITab, IDisposable
    {
        [CascadingParameter] protected TabSet ContainerTabSet { get; set; }
        [Parameter] protected string Title { get; set; }
        [Parameter] public RenderFragment ChildContent { get; private set; }

        protected bool IsActive => ContainerTabSet.ActiveTab == this;
        protected string ActiveCssClass => IsActive ? "active" : String.Empty;

        protected override void OnInit()
        {
            ContainerTabSet.AddTab(this);
        }

        public void Dispose()
        {
            ContainerTabSet.RemoveTab(this);
        }

        protected void Activate()
        {
            ContainerTabSet.SetActiveTab(this);
        }
    }
}
