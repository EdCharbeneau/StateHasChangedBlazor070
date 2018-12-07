using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;

namespace StateHasChangedBlazor070.Components.Tabs
{
    public class TabComponent : BlazorComponent, ITab, IDisposable
    {
        // Set by CascadingValue Component
        [CascadingParameter] protected TabSet ContainerTabSet { get; set; }

#pragma warning disable BL9993 // Component parameter is marked public due to ITab requirement
        [Parameter] public RenderFragment ChildContent { get; private set; }
#pragma warning restore BL9993 // Component parameter is marked public

        [Parameter] protected bool Disabled { get; set; }

        [Parameter]         
        /// <summary>
        /// The Tab Title
        /// </summary>
        protected string Title { get; set; }

        protected bool IsActive => ContainerTabSet.ActiveTab == this;
        protected string ActiveCssClass => IsActive ? "bl-active" : String.Empty;
        protected string DisabledCssClass => Disabled ? "bl-disabled" : String.Empty;

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
            if (Disabled) return;
            ContainerTabSet.SetActiveTab(this);
        }
    }
}
