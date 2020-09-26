﻿using Dock.Avalonia.Controls;
using Dock.Model;
using Dock.Model.Controls;
using AvaloniaRib.ViewModels;
using AvaloniaRib.ViewModels.Documents;
using AvaloniaRib.ViewModels.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRib
{
    public class RibbonFactory : Factory
    {
        public override IDock? CreateLayout()
        {
            var untitledFileViewModel = new FileViewModel()
            {
                Path = string.Empty,
                Title = "Untitled",
                Text = "",
                Encoding = Encoding.Default.WebName
            };

            var findViewModel = new FindViewModel
            {
                Id = "Find",
                Title = "Find"
            };

            var replaceViewModel = new ReplaceViewModel
            {
                Id = "Replace",
                Title = "Replace"
            };

            var files = new DocumentDock
            {
                Id = MainWindowViewModel.DocumentsDockId,
                Title = MainWindowViewModel.DocumentsDockId,
                IsCollapsable = false,
                Proportion = double.NaN,
                ActiveDockable = untitledFileViewModel,
                VisibleDockables = CreateList<IDockable>
                (
                    untitledFileViewModel
                )
            };

            var tools = new ProportionalDock
            {
                Proportion = 0.2,
                Orientation = Orientation.Vertical,
                VisibleDockables = CreateList<IDockable>
                (
                    new ToolDock
                    {
                        Proportion = double.NaN,
                        ActiveDockable = findViewModel,
                        VisibleDockables = CreateList<IDockable>
                        (
                            findViewModel
                        )
                    },
                    new SplitterDock(),
                    new ToolDock
                    {
                        Proportion = double.NaN,
                        ActiveDockable = replaceViewModel,
                        VisibleDockables = CreateList<IDockable>
                        (
                            replaceViewModel
                        )
                    }
                )
            };

            var windowLayout = CreateRootDock();
            windowLayout.Title = "Default";
            var windowLayoutContent = new ProportionalDock
            {
                Proportion = double.NaN,
                Orientation = Orientation.Horizontal,
                IsCollapsable = false,
                VisibleDockables = CreateList<IDockable>
                (
                    files,
                    new SplitterDock(),
                    tools
                )
            };
            windowLayout.IsCollapsable = false;
            windowLayout.VisibleDockables = CreateList<IDockable>(windowLayoutContent);
            windowLayout.ActiveDockable = windowLayoutContent;

            var root = CreateRootDock();

            root.IsCollapsable = false;
            root.VisibleDockables = CreateList<IDockable>(windowLayout);
            root.ActiveDockable = windowLayout;
            root.DefaultDockable = windowLayout;

            return root;
        }

        public override void InitLayout(IDockable layout)
        {
            this.ContextLocator = new Dictionary<string, Func<object>>
            {
                ["Find"] = () => layout,
                ["Replace"] = () => layout
            };

            this.HostWindowLocator = new Dictionary<string, Func<IHostWindow>>
            {
                [nameof(IDockWindow)] = () => new HostWindow()
            };

            this.DockableLocator = new Dictionary<string, Func<IDockable>>
            {
            };

            base.InitLayout(layout);
        }
    }
}
