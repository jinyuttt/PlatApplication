using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PlatClient.Views
{
    public class FileView : UserControl
    {
        public FileView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
