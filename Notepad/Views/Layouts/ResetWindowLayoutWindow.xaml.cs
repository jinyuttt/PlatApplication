﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Notepad.Views.Layouts
{
    public class ResetWindowLayoutWindow : Window
    {
        public ResetWindowLayoutWindow()
        {
            this.InitializeComponent();
           // this.AttachDevTools();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
