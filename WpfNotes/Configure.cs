using System.IO;
using System.Linq;

namespace WpfNotes
{
    public class Configure
    {
        public static string NoteFolder = "Files";
        public static int AutoSaveSec = 2;

        public static void CheckNotesFolder()
        {
            if (!Directory.Exists(Configure.NoteFolder))
            {
                Directory.CreateDirectory(Configure.NoteFolder);
            }
        }

        public static string[] LoadNotesFolder()
        {
            CheckNotesFolder();
            var files = Directory.GetFiles(Configure.NoteFolder);
            var names = files.Select(x => new FileInfo(x).Name).ToArray();
            return names;
        }

        public static string GetFilePath(string filename)
        {
            return Path.Combine(NoteFolder, filename);
        }
    }
}
