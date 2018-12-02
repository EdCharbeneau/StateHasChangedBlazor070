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
        Enum DefaultTab { get; set; }

        [Parameter]
        /// <summary>
        /// Gets or Sets the current tab selection.
        /// </summary>
        protected Enum Selected
        {
            get => selected ?? DefaultTab;
            set
            {
                if (tabs.ContainsKey(value))
                {
                    SetActiveTab(tabs[value]);
                }
            }
        }

        [Parameter]
        /// <summary>
        /// The Action invoked when the Selected value is changed.
        /// </summary>
        protected Action<Enum> SelectedChanged { get; set; }

        /// <summary>
        /// Active tab state consumed by child tab components
        /// </summary>
        public ITab ActiveTab { get; private set; }

        protected Enum selected;

        protected Dictionary<Enum, ITab> tabs = new Dictionary<Enum, ITab>();

        /// <summary>
        /// Registers a Tab within a TabSet
        /// </summary>
        /// <param name="tab"></param>
        public void AddTab(ITab tab)
        {
            tabs.Add(tab.Name, tab);
            if (ActiveTab == null || DefaultTab == null || (tab.Name.ToString() == DefaultTab.ToString() && tab.Name.GetType().Name == DefaultTab.GetType().Name))
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
            tabs.Remove(tab.Name);
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
            if (tab != null && ActiveTab != tab)
            {
                ActiveTab = tab;
                selected = tab.Name;
                SelectedChanged?.Invoke(selected);
                StateHasChanged();
            }
        }
    }
}
