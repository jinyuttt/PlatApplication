﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Notepad.Views.Layouts
{
    public class SaveWindowLayoutWindow : Window
    {
        public SaveWindowLayoutWindow()
        {
            this.InitializeComponent();
            //this.AttachDevTools();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
