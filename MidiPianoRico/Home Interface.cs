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
    Open picture in folder
    Show note help
    Remember latest category and song
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
        //private Bitmap[] pages;
        private Settings settings;
        ToolStripComboBox folderComboBox, songComboBox;

        public Home()
        {
            Text = "MidiPianoRico";
            hUIKeyboardHandler = new HUIKeyboardHandler(this, 1);
            settings = FileHandler.LoadSettings();
            SetSize();
            AddControls();
        }

        private void SetSize()
        {
            Rectangle screenSize = Screen.GetWorkingArea(this);
            this.Size = new Size(screenSize.Width, screenSize.Height);
            WindowState = FormWindowState.Maximized;
        }

        private void AddControls()
        {
            ToolStrip toolStrip = new ToolStrip();
            Controls.Add(toolStrip);

            ToolStripLabel folderLabel = new ToolStripLabel();
            folderLabel.Text = "Folder";
            toolStrip.Items.Add(folderLabel);

            folderComboBox = new ToolStripComboBox();
            folderComboBox.AutoSize = false;
            SetComboBoxItems(folderComboBox, settings.folderPaths);
            folderComboBox.SelectedIndexChanged += FolderComboBox_SelectedIndexChanged;
            toolStrip.Items.Add(folderComboBox);

            ToolStripLabel songLabel = new ToolStripLabel();
            songLabel.Text = "Song";
            toolStrip.Items.Add(songLabel);

            songComboBox = new ToolStripComboBox();
            songComboBox.AutoSize = false;
            songComboBox.Width = 25;
            toolStrip.Items.Add(songComboBox);

            ToolStripButton showSongButton = new ToolStripButton();
            showSongButton.Text = "Show song";
            showSongButton.Click += ShowSongButton_Click;
            toolStrip.Items.Add(showSongButton);

            toolStrip.Items.Add(new ToolStripSeparator());

            ToolStripButton showHelpButton = new ToolStripButton();
            showHelpButton.Text = "Show help";
            showHelpButton.Click += ShowHelpButton_Click;
            toolStrip.Items.Add(showHelpButton);

            ToolStripButton launchPlayerButton = new ToolStripButton();
            launchPlayerButton.Text = "Launch player";
            launchPlayerButton.Click += LaunchPlayerButton_Click;
            toolStrip.Items.Add(launchPlayerButton);

            toolStrip.Items.Add(new ToolStripSeparator());

            ToolStripButton addFolderButton = new ToolStripButton();
            addFolderButton.Text = "Add folder";
            addFolderButton.Click += AddFolderButton_Click;
            toolStrip.Items.Add(addFolderButton);

            ToolStripButton changePlayerButton = new ToolStripButton();
            changePlayerButton.Text = "Change player";
            changePlayerButton.Click += ChangePlayerButton_Click;
            toolStrip.Items.Add(changePlayerButton);

            ToolStripButton changeInputButton = new ToolStripButton();
            changeInputButton.Text = "Change input";
            changeInputButton.Click += ChangeInputButton_Click;
            toolStrip.Items.Add(changeInputButton);

            pictureBox = new PictureBox();
            pictureBox.Size = new Size(Size.Width, Size.Height - toolStrip.Height);
            pictureBox.Location = new Point(0, toolStrip.Height);
            Controls.Add(pictureBox);
        }

        private void SetComboBoxItems(ToolStripComboBox comboBox, List<string> items)
        {
            comboBox.Items.Clear();
            int maxWidth = 25;
            Graphics graphics = Graphics.FromImage(new Bitmap(10, 10));
            foreach (string item in items)
            {
                comboBox.Items.Add(item);
                maxWidth = Math.Max(maxWidth, (int)graphics.MeasureString(item, Font).Width + 25);
            }
            comboBox.Width = maxWidth;
            comboBox.DropDownWidth = maxWidth;
        }

        private void NextPicture()
        {
            throw new NotImplementedException();
        }

        private void PreviousPicture()
        {
            throw new NotImplementedException();
        }
    }
}
