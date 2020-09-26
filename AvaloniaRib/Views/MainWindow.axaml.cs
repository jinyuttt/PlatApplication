﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Ribbon;
using Avalonia.Markup.Xaml;

namespace AvaloniaRib.Views
{
    public class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            //this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
