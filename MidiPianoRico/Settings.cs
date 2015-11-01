using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiPianoRico
{
    class Settings
    {
        public string playerPath = "C:/Program Files (x86)/vmpk/vmpk.exe";
        public int inputID = 1;
        public List<string> folderPaths = new List<string>();

        public Settings()
        {
            
        }

        public Settings(List<string> lines)
        {
            try
            {
                playerPath = lines[0];
                inputID = int.Parse(lines[1]);
                if (lines.Count > 2)
                {
                    for (int i = 2; i < lines.Count; i++)
                    {
                        folderPaths.Add(lines[i]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("The settings file is corrupt. Default settings are loaded");
            }
        }
        
        public List<string> ToLines()
        {
            List<string> lines = new List<string>();
            lines.Add(playerPath);
            lines.Add(inputID.ToString());
            if (folderPaths.Count > 0)
            {
                for (int i = 0; i < folderPaths.Count; i++)
                {
                    lines.Add(folderPaths[i]);
                }
            }
            return lines;
        }
    }
}
