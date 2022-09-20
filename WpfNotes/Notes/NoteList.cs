using System.Collections.ObjectModel;
using System.IO;

namespace WpfNotes.Notes
{
    public class NoteList
    {
        public ObservableCollection<NoteInfo> Notes { get; set; } = new ObservableCollection<NoteInfo>();

        public void AddNewNote()
        {
            var note = new NoteInfo("Untitled" + Notes.Count);
            CreateNoteFile(note);
            Notes.Add(note);
        }

        public void CreateNoteFile(NoteInfo note)
        {
            Configure.CheckNotesFolder();
            if (!string.IsNullOrEmpty(note.FileName))
            {
                var file = File.CreateText(Configure.GetFilePath(note.FileName));
                file.WriteLine(note.NoteTitle);
                file.Close();
            }
        }

        public void LoadFromFiles(string[] files)
        {
            foreach(var file in files)
            {
                var fullPath = Configure.GetFilePath(file);
                if (File.Exists(fullPath))
                {
                    var fileReader = File.OpenText(fullPath);
                    var firstLine = fileReader.ReadLine();
                    var note = new NoteInfo(firstLine, file);
                    Notes.Add(note);
                }
            }
        }
    }
}
