using Avalonia.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaloniaRib.ViewModels
{
   public interface IDropTarget
    {
        void DragOver(object? sender, DragEventArgs e);
        void Drop(object? sender, DragEventArgs e);
    }
}
