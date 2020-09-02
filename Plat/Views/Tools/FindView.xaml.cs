using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PlatForm.Views.Tools
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
