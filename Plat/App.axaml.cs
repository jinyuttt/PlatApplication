using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Dock.Model;
using PlatForm.ViewModels;
using PlatForm.Views;

namespace PlatForm
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var mainWindowViewModel = new MainWindowViewModel();

           

            var factory = new RibbonFactory();
            IDock? layout = null;

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
               

                var mainWindow = new MainWindow
                {
                    DataContext = mainWindowViewModel
                };

                // TODO: Restore main window position, size and state.

                mainWindowViewModel.Factory = factory;
                mainWindowViewModel.Layout = layout ?? mainWindowViewModel.Factory?.CreateLayout();

                if (mainWindowViewModel.Layout != null)
                {
                    mainWindowViewModel.Factory?.InitLayout(mainWindowViewModel.Layout);
                }

                mainWindow.Closing += (sender, e) =>
                {
                    if (mainWindowViewModel.Layout is IDock dock)
                    {
                        dock.Close();
                    }
                    // TODO: Save main window position, size and state.
                };

                desktopLifetime.MainWindow = mainWindow;

                desktopLifetime.Exit += (sennder, e) =>
                {
                    if (mainWindowViewModel.Layout is IDock dock)
                    {
                        dock.Close();
                    }
                    
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewLifetime)
            {
                var mainView = new MainView()
                {
                    DataContext = mainWindowViewModel
                };

                mainWindowViewModel.Factory = factory;
                mainWindowViewModel.Layout = layout ?? mainWindowViewModel.Factory?.CreateLayout();

                if (mainWindowViewModel.Layout != null)
                {
                    mainWindowViewModel.Factory?.InitLayout(mainWindowViewModel.Layout);
                }

                singleViewLifetime.MainView = mainView;
            }
            base.OnFrameworkInitializationCompleted();
        }

    }
}
