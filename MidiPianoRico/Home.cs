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
        private KeyboardHandler keyboardHandler;
        private FileHandler fileHandler;
        private Bitmap bitmap;
        public PictureBox pictureBox;

        public Home()
        {
            int width = 1920;
            int height = 1200;

            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Size = new Size(width, height);
            Text = "MidiPianoRico";

            int barHeight = 100;

            Button openImageButton = new Button();
            openImageButton.Size = new Size(width, barHeight);
            openImageButton.Location = new Point(0, 0);
            openImageButton.Click += OpenImageButton_Click;
            Controls.Add(openImageButton);

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(width, barHeight);
            pictureBox.Location = new Point(barHeight, height - barHeight);
            Controls.Add(pictureBox);



            keyboardHandler = new KeyboardHandler(this);
            fileHandler = new FileHandler(this);
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = fileHandler.OpenImage();
        }
    }
}
