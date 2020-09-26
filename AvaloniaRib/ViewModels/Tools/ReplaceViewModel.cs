﻿using System.Runtime.Serialization;
using Dock.Model;
using Dock.Model.Controls;
using AvaloniaRib.ViewModels.Documents;
using ReactiveUI;

namespace AvaloniaRib.ViewModels.Tools
{
    public class ReplaceViewModel : Tool
    {
        private string _find = string.Empty;
        private string _replace = string.Empty;

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public string Find
        {
            get => _find;
            set => this.RaiseAndSetIfChanged(ref _find, value);
        }

        [DataMember(IsRequired = false, EmitDefaultValue = true)]
        public string Replace
        {
            get => _replace;
            set => this.RaiseAndSetIfChanged(ref _replace, value);
        }

        public void ReplaceNext()
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
