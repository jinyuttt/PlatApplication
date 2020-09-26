using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Input;
using Dock.Model;
using AvaloniaRib.ViewModels.Documents;
using ReactiveUI;
using System;
using System.IO;
using System.Text;


namespace AvaloniaRib.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IDropTarget
    {
        public static string DocumentsDockId { get; internal set; }

        private IFactory? _factory;
        private IDock? _layout;
        public IFactory? Factory
        {
            get => _factory;
            set => this.RaiseAndSetIfChanged(ref _factory, value);
        }

        public IDock? Layout
        {
            get => _layout;
            set => this.RaiseAndSetIfChanged(ref _layout, value);
        }

        public void OnClickCommand(object parameter)
        {
            string paramString = "[NO CONTENT]";

            if (parameter != null)
            {
                if (parameter is string str)
                    paramString = str;
                else
                    paramString = parameter.ToString();
            }

            Console.WriteLine("OnClickCommand invoked: " + paramString);
            //LastActionText = paramString;
            this.FileNew();
        }

        private FileViewModel OpenFileViewModel(string path)
        {
            Encoding encoding = Encoding.Default;
            string text = File.ReadAllText(path, encoding);
            string title = Path.GetFileName(path);
            return new FileViewModel()
            {
                Path = path,
                Title = title,
                Text = text,
                Encoding = encoding.WebName
            };
        }

     
        private void AddFileViewModel(FileViewModel fileViewModel)
        {
            if (Layout?.ActiveDockable is IDock active)
            {
                if (active.Factory?.FindDockable(active, (d) => d.Id == DocumentsDockId) is IDock files)
                {
                    Factory?.AddDockable(files, fileViewModel);
                    Factory?.SetActiveDockable(fileViewModel);
                    Factory?.SetFocusedDockable(Layout, fileViewModel);
                }
            }
        }

        private FileViewModel? GetFileViewModel()
        {
            if (Layout?.ActiveDockable is IDock active)
            {
                if (active.Factory?.FindDockable(active, (d) => d.Id == DocumentsDockId) is IDock files)
                {
                    return files.ActiveDockable as FileViewModel;
                }
            }
            return null;
        }

        private FileViewModel GetUntitledFileViewModel()
        {
            return new FileViewModel()
            {
                Path = string.Empty,
                Title = "Untitled",
                Text = "",
                Encoding = Encoding.Default.WebName
            };
        }

        public void FileNew()
        {
            var untitledFileViewModel = GetUntitledFileViewModel();
            if (untitledFileViewModel != null)
            {
                AddFileViewModel(untitledFileViewModel);
            }
        }

       
        public void DragOver(object? sender, DragEventArgs e)
        {
            if (!e.Data.Contains(DataFormats.FileNames))
            {
                e.DragEffects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        public void Drop(object? sender, DragEventArgs e)
        {
            if (e.Data.Contains(DataFormats.FileNames))
            {
                var result = e.Data.GetFileNames();

                foreach (var path in result)
                {
                    if (!string.IsNullOrEmpty(path))
                    {
                        var untitledFileViewModel = OpenFileViewModel(path);
                        if (untitledFileViewModel != null)
                        {
                            AddFileViewModel(untitledFileViewModel);
                        }
                    }
                }

                e.Handled = true;
            }
        }

        private void CopyDocuments(IDock source, IDock target, string id)
        {
            if (source.Factory?.FindDockable(source, (d) => d.Id == id) is IDock sourceFiles
                && target.Factory?.FindDockable(target, (d) => d.Id == id) is IDock targetFiles
                && sourceFiles.VisibleDockables != null
                && targetFiles.VisibleDockables != null)
            {
                targetFiles.VisibleDockables.Clear();
                targetFiles.ActiveDockable = null;

                foreach (var visible in sourceFiles.VisibleDockables)
                {
                    targetFiles.VisibleDockables.Add(visible);
                }

                targetFiles.ActiveDockable = sourceFiles.ActiveDockable;
            }
        }

    
       
        private Window? GetWindow()
        {
            if (Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
            {
                return desktopLifetime.MainWindow;
            }
            return null;
        }
    }
}
