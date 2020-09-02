using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace PlatForm.Views.Documents
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
