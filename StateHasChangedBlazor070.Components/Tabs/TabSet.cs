using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;

namespace StateHasChangedBlazor070.Components.Tabs
{
    public class TabSetComponent : BlazorComponent
    {
        [Parameter] protected RenderFragment ChildContent { get; set; }

        [Parameter]
        /// <summary>
        /// Sets the default tab when the component initializes.
        /// </summary>
        protected int DefaultTab { get; set; }

        [Parameter]
        /// <summary>
        /// Gets or Sets the current tab selection.
        /// </summary>
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

        [Parameter]
        /// <summary>
        /// The Action invoked when the Selected value is changed.
        /// </summary>
        protected Action<int> SelectedChanged { get; set; }

        /// <summary>
        /// Active tab state consumed by child tab components
        /// </summary>
        public ITab ActiveTab { get; private set; }

        protected int? selected;

        protected List<ITab> tabs = new List<ITab>();

        /// <summary>
        /// Registers a Tab within a TabSet
        /// </summary>
        /// <param name="tab"></param>
        public void AddTab(ITab tab)
        {
            tabs.Add(tab);
            if (ActiveTab == null || tabs.Count - 1 == DefaultTab)
            {
                SetActiveTab(tab);
            }
        }

        /// <summary>
        /// Removes a Tab within a TabSet
        /// </summary>
        /// <param name="tab"></param>
        public void RemoveTab(ITab tab)
        {
            tabs.Remove(tab);
            if (ActiveTab == tab)
            {
                SetActiveTab(null);
            }
        }

        /// <summary>
        /// Sets the active Tab
        /// </summary>
        /// <param name="tab"></param>
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
