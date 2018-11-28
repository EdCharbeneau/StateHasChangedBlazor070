using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;

namespace StateHasChangedBlazor070.Components.Tabs
{
    public class TabSetComponent : BlazorComponent
    {
        [Parameter] protected RenderFragment ChildContent { get; set; }

        [Parameter] protected int DefaultTab { get; set; }

        [Parameter]
        protected int Selected
        {
            get
            {
                return selected.Value;
            }
            set
            {
                if (value >= 0 && value <= tabs.Count - 1)
                {
                    SetActiveTab(tabs[value]);
                }
            }
        }

        [Parameter] protected Action<int> SelectedChanged { get; set; }

        public ITab ActiveTab { get; private set; }

        protected int? selected;

        protected List<ITab> tabs = new List<ITab>();

        public void AddTab(ITab tab)
        {
            tabs.Add(tab);
            if (ActiveTab == null || tabs.Count - 1 == DefaultTab)
            {
                SetActiveTab(tab);
            }
        }

        public void RemoveTab(ITab tab)
        {
            tabs.Remove(tab);
            if (ActiveTab == tab)
            {
                SetActiveTab(null);
            }
        }

        public void SetActiveTab(ITab tab)
        {
            if (ActiveTab != tab)
            {
                ActiveTab = tab;
                selected = tabs.IndexOf(tab);
                SelectedChanged?.Invoke(selected.Value);
                StateHasChanged();
            }
        }
    }
}
