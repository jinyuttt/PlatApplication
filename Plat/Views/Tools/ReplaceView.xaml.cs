using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PlatForm.Views.Tools
{
    public class ReplaceView : UserControl
    {
        public ReplaceView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
