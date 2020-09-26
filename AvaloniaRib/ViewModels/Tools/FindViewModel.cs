﻿using System.Runtime.Serialization;
using Dock.Model;
using Dock.Model.Controls;
using AvaloniaRib.ViewModels.Documents;
using ReactiveUI;

namespace AvaloniaRib.ViewModels.Tools
{
    public class FindViewModel : Tool
    {
        private string _find = string.Empty;

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public string Find
        {
            get => _find;
            set => this.RaiseAndSetIfChanged(ref _find, value);
        }

        public void FindNext()
        {
            if (this.Context is IRootDock root && root.ActiveDockable is IDock active)
            {
                if (active.Factory?.FindDockable(active, (d) => d.Id == MainWindowViewModel.DocumentsDockId) is IDock files)
                {
                    if (files.ActiveDockable is FileViewModel fileViewModel)
                    {
                        // TODO: 
                    }
                }
            }
        }
    }
}
