using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Sanford.Multimedia.Midi.UI;

namespace MidiPianoRico
{
    partial class Home : Form
    {

        private void FolderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = ((ToolStripComboBox)sender).SelectedItem.ToString();
            SetComboBoxItems(songComboBox, FileHandler.GetFilePaths(path));
        }

        private void ShowSongButton_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = FileHandler.OpenPNG();
            if (bitmap != null)
            {
                float ratio = (float)bitmap.Width / pictureBox.Width;
                if (ratio > 1)
                {
                    MessageBox.Show("pictureBox width: " + pictureBox.Width + " bitmap width: " + bitmap.Width + " ratio: " + ratio + " new bitmap width: " + ((int)((float)bitmap.Width / ratio)));
                    bitmap = new Bitmap(bitmap, (int)((float)bitmap.Width / ratio), (int)((float)bitmap.Height / ratio));
                }
                pictureBox.Image = bitmap;
                pictureBox.Size = bitmap.Size;
            }
        }

        private void ShowHelpButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LaunchPlayerButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(settings.playerPath);
        }

        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                settings.folderPaths.Add(dialog.SelectedPath);
                settings.folderPaths.Sort();
                FileHandler.SaveSettings(settings);
                SetComboBoxItems(folderComboBox, settings.folderPaths);
            }
            else
            {
                MessageBox.Show("No new folder is selected");
            }
        }

        private void ChangePlayerButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                settings.playerPath = dialog.FileName;
            }
            else
            {
                MessageBox.Show("No new player is selected");
            }
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
            NextPicture();
        }

        public void HandleDownButtonPress()
        {
            PreviousPicture();
        }

        public void HandleLeftButtonPress() { }

        public void HandleRightButtonPress() { }

        public void HandleCenterButtonPress() { }

        private void ShowHideHelp()
        {

        }
    }
}
