using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidiPianoRico
{
    static class MidiEventReader
    {
        public static MidiEvent ReadEvent(Stream stream)
        {
            int[] first = Split(stream.ReadByte());

            switch (first[0])
            {
                case 8:
                    return new NoteOff(first[1], stream.ReadByte(), stream.ReadByte());

                case 9:
                    return new NoteOn(first[1], stream.ReadByte(), stream.ReadByte());

                /*case 0:
                    switch (first[1])
                    {
                        case 1
                    }*/

                default:
                    System.Windows.Forms.MessageBox.Show("Error: " + first[0] + ' ' + first[1]);
                    return new OtherMidiEvent(first[1], stream.ReadByte(), stream.ReadByte());
            }
        }

        private static int[] Split(int both)
        {
            int[] result = new int[2];
            result[0] = (int)Math.Floor((double)both / 16);
            result[1] = both - result[0];
            return result;
        }
    }
}
