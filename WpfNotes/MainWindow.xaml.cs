using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfNotes.Notes;

namespace WpfNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NoteList NoteList { get; set; } = new NoteList();
        public Timer SaveTimer { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            var files = Configure.LoadNotesFolder();
            NoteList.LoadFromFiles(files);
            SaveTimer = new Timer(Configure.AutoSaveSec * 1000);
            SaveTimer.Elapsed += SaveNotes;
            SaveTimer.Enabled = true;
            SaveTimer.AutoReset = true;
        }

        public void AddNote(object sender, RoutedEventArgs e)
        {
            NoteList.AddNewNote();
            Tabs.SelectedIndex=NoteList.Notes.Count-1;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textEditor.SaveFile();
            if (e.AddedItems.Count>0)
            {
                var note = e.AddedItems[0] as NoteInfo;
                textEditor.LoadFile(Configure.GetFilePath(note!.FileName));
            }
        }

        public void SaveNotes(Object source, ElapsedEventArgs e)
        {
            textEditor.SaveFile();
        }
    }
}
