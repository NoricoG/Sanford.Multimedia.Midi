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
            return new Settings();
        }

        public static string SelectVMPKPath()
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.InitialDirectory = "C:/Program Files (x86)/vmpk";
                open.FileName = "vmpk.exe";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    return open.FileName;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error: Failed selecting VMPK path");
            }
        }
    }
}
