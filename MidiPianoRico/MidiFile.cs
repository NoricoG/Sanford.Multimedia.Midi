using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiPianoRico
{
    class MidiFile
    {
        public int fileFormat, numberOfTracks, deltaTicksPerQuarter;
        public MidiEvent[][] tracks;

        public MidiFile()
        {

        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("FileFormat: ");
            stringBuilder.Append(fileFormat);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("Number Of Tracks: ");
            stringBuilder.Append(numberOfTracks);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("Delta Ticks Per Quarter: ");
            stringBuilder.Append(deltaTicksPerQuarter);

            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);

            for(int i = 0; i < tracks.Length; i++)
            {
                stringBuilder.Append("Track ");
                stringBuilder.Append(i);
                stringBuilder.Append(':');
                stringBuilder.Append(Environment.NewLine);

                for (int j = 0; j < tracks[i].Length; j++)
                {
                    stringBuilder.Append(tracks[i][j]);
                }

                stringBuilder.Append(Environment.NewLine);
                stringBuilder.Append(Environment.NewLine);
            }

            return stringBuilder.ToString();
        }
    }
}
