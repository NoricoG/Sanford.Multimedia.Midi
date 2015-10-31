using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

/*
TODO:
    Open image
    Scroll image
    Show note help
    Base folder with selecting through categories
    Remember category and song
    
    Choose output

    Open midi file
    Draw midi file
    Choose input?
    Play midi file
*/

namespace MidiPianoRico
{
    partial class Home : Form
    {
        KeyboardHandler keyboardHandler;
        FileHandler fileHandler;
        MidiFile midiFile;

        public Home()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Size = new Size(1920, 1200);
            Text = "MidiPianoRico";

            keyboardHandler = new KeyboardHandler(this);
            fileHandler = new FileHandler(this);

            Click += ClickHandler;
        }

        private void ClickHandler(Object sender, EventArgs e)
        {
            midiFile = fileHandler.OpenFile();
            MessageBox.Show(midiFile.ToString());
        }
    }
}
