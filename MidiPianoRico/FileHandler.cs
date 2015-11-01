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
    class FileHandler
    {
        private Home home;

        public FileHandler(Home home)
        {
            this.home = home;
        }

        public Bitmap OpenPNG()
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
                    throw new ApplicationException("Error: Failed loading image");
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Error: Failed loading image");
            }
        }
    }
}
