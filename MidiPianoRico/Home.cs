using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Sanford.Multimedia.Midi.UI;

/*
TODO:
    Show note help
    Base folder with selecting through categories
    Remember category and song
    Handle multiple pages
    
Maybe:
    Output with low latency witouth VMPK
    Open, draw and play midi file
*/

namespace MidiPianoRico
{
    partial class Home : Form
    {
        private HUIKeyboardHandler hUIKeyboardHandler;
        public PictureBox pictureBox;
        private Bitmap nextPage;
        private Settings settings;

        public Home()
        {
            Text = "MidiPianoRico";

            WindowState = FormWindowState.Maximized;
            Rectangle size = Screen.GetWorkingArea(this);
            Size = new Size(size.Width, size.Height);

            int numberOfButtons = 5;
            
            int edgeMargin = 5;
            int betweenMargin = 5;
            int buttonWidth = Size.Width / numberOfButtons;
            int buttonHeight = 30;

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(Size.Width, Size.Height - buttonHeight - 2 * edgeMargin);
            pictureBox.Location = new Point(0, buttonHeight + 2 * edgeMargin);
            Controls.Add(pictureBox);
            BackColor = Color.Black;
            pictureBox.BackColor = Color.Green;

            int currentX = edgeMargin;

            Button openImageButton = new Button();
            openImageButton.Text = "Open image";
            openImageButton.Size = new Size(buttonWidth, buttonHeight);
            openImageButton.Location = new Point(currentX, edgeMargin);
            openImageButton.Click += OpenImageButton_Click;
            Controls.Add(openImageButton);

            currentX += buttonWidth + betweenMargin;

            Button showHelpButton = new Button();
            showHelpButton.Text = "Show help";
            showHelpButton.Size = new Size(buttonWidth, buttonHeight);
            showHelpButton.Location = new Point(currentX, edgeMargin);
            openImageButton.Click += ShowHelpButton_Click;
            Controls.Add(showHelpButton);

            currentX += buttonWidth + betweenMargin;

            Button runVMPKButton = new Button();
            runVMPKButton.Text = "Run VMPK";
            runVMPKButton.Size = new Size(buttonWidth, buttonHeight);
            runVMPKButton.Location = new Point(currentX, edgeMargin);
            runVMPKButton.Click += RunVMPKButton_Click;
            Controls.Add(runVMPKButton);

            currentX += buttonWidth + betweenMargin;

            Button browseVMPKButton = new Button();
            browseVMPKButton.Text = "Select VMPK Location";
            browseVMPKButton.Size = new Size(buttonWidth, buttonHeight);
            browseVMPKButton.Location = new Point(currentX, edgeMargin);
            browseVMPKButton.Click += BrowseVMPKButton_Click;
            Controls.Add(browseVMPKButton);

            currentX += buttonWidth + betweenMargin;

            Button changeInputButton = new Button();
            changeInputButton.Text = "Change input";
            changeInputButton.Size = new Size(buttonWidth, buttonHeight);
            changeInputButton.Location = new Point(currentX, edgeMargin);
            openImageButton.Click += ShowHelpButton_Click;
            Controls.Add(showHelpButton);

            hUIKeyboardHandler = new HUIKeyboardHandler(this, 1);
            settings = FileHandler.LoadSettings();
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = FileHandler.OpenPNG();
            if (bitmap != null)
            {
                float ratio = (float)bitmap.Width / pictureBox.Width;
                MessageBox.Show(bitmap.Width.ToString());
                MessageBox.Show(pictureBox.Width.ToString());
                MessageBox.Show(ratio.ToString());
                if (ratio > 1)
                {
                    bitmap = new Bitmap(bitmap, (int)((float)bitmap.Width / ratio), (int)((float)bitmap.Height / ratio));
                    MessageBox.Show(bitmap.Width.ToString());
                }
                pictureBox.Image = bitmap;
                pictureBox.Size = bitmap.Size;
            }
        }

        private void ShowHelpButton_Click(object sender, EventArgs e)
        {
            ShowHideHelp();
            //System.Diagnostics.Process.Start("C:/FILES/OneDrive/Muziek/Hulp/Octaven.jpg");
        }

        private void RunVMPKButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settings.vMPKPath);
        }

        private void BrowseVMPKButton_Click(object sender, EventArgs e)
        {
            settings.vMPKPath = FileHandler.SelectVMPKPath();
        }

        private void ChangeInputButton_Click(object sender, EventArgs e)
        {
            InputDeviceDialog dialog = new InputDeviceDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                hUIKeyboardHandler = new HUIKeyboardHandler(this, dialog.InputDeviceID);
            }
            else
            {
                MessageBox.Show("No new input device is selected");
            }
        }

        public void HandleStopButtonPress() { }

        public void HandlePlayButtonPress() { }

        public void HandleRecordButtonPress() { }

        public void HandleUpButtonPress()
        {
            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + Size.Height * 2 / 3);
        }

        public void HandleDownButtonPress()
        {
            pictureBox.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y - Size.Height * 2 / 3);
        }

        public void HandleLeftButtonPress() { }

        public void HandleRightButtonPress() { }

        public void HandleCenterButtonPress() { }

        private void ShowHideHelp()
        {

        }
    }
}
