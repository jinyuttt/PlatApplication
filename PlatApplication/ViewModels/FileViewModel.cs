using Dock.Model.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlatClient.ViewModels
{
    public class FileViewModel : Document
    {
        public string Path { get; internal set; }
        public string Encoding { get; internal set; }
        public string Text { get; internal set; }
    }
}
