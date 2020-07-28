using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PlatClient.Views
{
    public class FindView : UserControl
    {
        public FindView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
