using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MidiPianoRico
{
    class FileHandler
    {
        private Home home;

        public FileHandler(Home home)
        {
            this.home = home;
        }

        public MidiFile OpenFile()
        {
            OpenFileDialog openMidiFileDialog = new OpenFileDialog();
            if (openMidiFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openMidiFileDialog.FileName;

                try
                {
                    FileStream fileStream = new FileStream(fileName, FileMode.Open);
                    FindFileHeader(fileStream);

                    MidiFile midiFile = new MidiFile();
                    midiFile.fileFormat = fileStream.ReadByte();
                    midiFile.numberOfTracks = fileStream.ReadByte();
                    midiFile.deltaTicksPerQuarter = fileStream.ReadByte();
                    midiFile.tracks = new MidiEvent[3][];

                    for (int i = 0; i < midiFile.numberOfTracks; i++)
                    {
                        FindTrackHeader(fileStream);
                        int numberOfEvents = fileStream.ReadByte() * 255^3 + fileStream.ReadByte() * 255 ^ 2 + fileStream.ReadByte() * 255 + fileStream.ReadByte();
                        midiFile.tracks[i] = new MidiEvent[numberOfEvents];

                        for (int j = 0; j < numberOfEvents; j++)
                        {
                            
                            midiFile.tracks[i][j] = MidiEventReader.ReadEvent(fileStream);
                        }
                    }

                    return midiFile;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return new MidiFile();
        }

        private static readonly byte[] MidiFileHeader =
        {
            (byte)'M',
            (byte)'T',
            (byte)'h',
            (byte)'d',
            0,
            0,
            0,
            6
        };

        private void FindFileHeader(Stream stream)
        {
            bool found = false;
            int result;

            while (!found)
            {
                result = stream.ReadByte();

                if (result == 'M')
                {
                    result = stream.ReadByte();

                    if (result == 'T')
                    {
                        result = stream.ReadByte();

                        if (result == 'h')
                        {
                            result = stream.ReadByte();

                            if (result == 'd')
                            {
                                found = true;
                            }
                        }
                    }
                }

                if (result < 0)
                {
                    throw new Exception("Unable to find MIDI file header.");
                }
            }

            // Eat the header length.
            for (int i = 0; i < 4; i++)
            {
                if (stream.ReadByte() < 0)
                {
                    throw new Exception("Unable to find MIDI file header.");
                }
            }
        }

        private void FindTrackHeader(Stream stream)
        {
            bool found = false;
            int result;

            while (!found)
            {
                result = stream.ReadByte();

                if (result == 'M')
                {
                    result = stream.ReadByte();

                    if (result == 'T')
                    {
                        result = stream.ReadByte();

                        if (result == 'r')
                        {
                            result = stream.ReadByte();

                            if (result == 'k')
                            {
                                found = true;
                            }
                        }
                    }
                }

                if (result < 0)
                {
                    throw new Exception("Unable to find MIDI file header.");
                }
            }
        }
    }
}
