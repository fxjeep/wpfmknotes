using System;
using System.IO;

namespace WpfNotes.Notes
{
    public class NoteInfo
    {
        public string NoteTitle { get; set; } = "";
        public NoteStatus Status { get; set; }

        public string FileName { get; set; } = "";

        public NoteInfo(string title)
        {
            NoteTitle = title;
            FileName = DateTime.Now.ToString("yyyymmdd_HHmmss") + "_" + DateTime.Now.Ticks + ".txt";
            Status = NoteStatus.Dirty;
        }

        public NoteInfo(string title, string filename)
        {
            NoteTitle = title;
            FileName = filename;
        }

        public string NoteTabHeader
        {
            get
            {
                return NoteTitle + " " + Status.ToString();
            }
        }
    }
}
