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

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(width, barHeight);
            pictureBox.Location = new Point(0, height - barHeight);
            Controls.Add(pictureBox);

            Button openImageButton = new Button();
            openImageButton.Size = new Size(width, barHeight);
            openImageButton.Location = new Point(0, 0);
            openImageButton.Click += OpenImageButton_Click;
            Controls.Add(openImageButton);

            keyboardHandler = new KeyboardHandler(this);
            fileHandler = new FileHandler(this);
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = fileHandler.OpenPNG();
            float ratio = bitmap.Width / pictureBox.Width;
            if (ratio > 1)
            {
                bitmap = new Bitmap(bitmap, (int)(bitmap.Width / ratio), (int)(bitmap.Height / ratio));
            }
            pictureBox.Image = bitmap;
            pictureBox.Size = bitmap.Size;
        }

        public void MovePictureBox()
        {
            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - 100);
        }
    }
}
