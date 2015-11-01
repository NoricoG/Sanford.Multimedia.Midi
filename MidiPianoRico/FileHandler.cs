using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace MidiPianoRico
{
    static class FileHandler
    {
        public static Bitmap OpenPNG()
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "PNG Image Files(*.png)|*.png;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    return new Bitmap(open.FileName);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error: Failed loading image");
            }
        }

        public static Settings LoadSettings()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MidiPianoRico");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path += "/settings.txt";

            if (File.Exists(path))
            {
                List<string> lines = new List<string>();
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string line = "";
                    while ((line = streamReader.ReadLine()) != null)
                        lines.Add(line);
                }
                return new Settings(lines);
            }
            else
            {
                Settings settings = new Settings();
                SaveSettings(settings);
                return settings;
            }
        }

        public static void SaveSettings(Settings settings)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MidiPianoRico/settings.txt");
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                foreach (string line in settings.ToLines())
                {
                    streamWriter.WriteLine(line);
                }
            }

        }

        public static List<string> GetFilePaths(string path)
        {
            List<string> paths = new List<string>();
            MessageBox.Show("The selected path is: " + path);
            string[] found = Directory.GetFiles(path, "*.mscz");
            for (int i = 0; i < found.Length; i++)
            {
                int filenameLength = found[i].Length - path.Length - 6;
                string filename = found[i].Substring(path.Length + 1, filenameLength);
                paths.Add(filename);
            }
            paths.Sort();
            return paths;
        }
    }
}
