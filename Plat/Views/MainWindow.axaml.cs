using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Ribbon;
using Avalonia.Markup.Xaml;


namespace PlatForm.Views
{
    public class MainWindow : Window
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
