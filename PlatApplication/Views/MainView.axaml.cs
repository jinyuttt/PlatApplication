﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using PlatClient.ViewModels;

namespace PlatClient.Views
{
    public class MainView : UserControl
    {
        public MainView()
        {
            this.InitializeComponent();
            AddHandler(DragDrop.DropEvent, Drop);
            AddHandler(DragDrop.DragOverEvent, DragOver);
        }

        private void DragOver(object? sender, DragEventArgs e)
        {
            if (this.DataContext is IDropTarget dropTarget)
            {
                dropTarget.DragOver(sender, e);
            }
        }

        private void Drop(object? sender, DragEventArgs e)
        {
            if (this.DataContext is IDropTarget dropTarget)
            {
                dropTarget.Drop(sender, e);
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
