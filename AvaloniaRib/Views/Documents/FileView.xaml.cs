using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace AvaloniaRib.Views.Documents
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
