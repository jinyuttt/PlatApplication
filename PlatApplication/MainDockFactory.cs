using Dock.Avalonia.Controls;
using Dock.Model;
using Dock.Model.Controls;

using PlatClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlatClient
{
   public class MainDockFactory : Factory
    {
        public override IDock CreateLayout()
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
            root.Top = CreatePinDock();
            root.Top.Alignment = Alignment.Top;
            root.Bottom = CreatePinDock();
            root.Bottom.Alignment = Alignment.Bottom;
            root.Left = CreatePinDock();
            root.Left.Alignment = Alignment.Left;
            root.Right = CreatePinDock();
            root.Right.Alignment = Alignment.Right;

            return root;
        }

        public override void InitLayout(IDockable layout)
        {
            this.ContextLocator = new Dictionary<string, Func<object>>
            {
                ["Find"] = () => layout,
                
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
