using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace WpfNotes.Editor
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class MarkdownEditor : UserControl
    {
        public string CurrentFileFullName { get; set; } = "";

        public MarkdownEditor()
        {
            InitializeComponent();
        }

        public void LoadFile(string fullName)
        {
            avalonEditor.Load(fullName);
            CurrentFileFullName = fullName;
        }

        public void SaveFile()
        {
            avalonEditor.Save(CurrentFileFullName);
        }

    }
}
