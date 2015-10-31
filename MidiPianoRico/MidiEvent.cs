using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiPianoRico
{

    abstract class MidiEventBase
    {

    }

    abstract class MidiEvent
    {
        public int channel;
    }

    class NoteOn : MidiEvent
    {
        public int noteNumber, velocity;

        public NoteOn(int channel, int noteNumber, int velocity)
        {
            this.noteNumber = noteNumber;
            this.velocity = velocity;
        }

        public override string ToString()
        {
            return "NoteOff " + ' ' + channel + noteNumber + ' ' + velocity;
        }
    }

    class NoteOff : MidiEvent
    {
        public int noteNumber, velocity;

        public NoteOff(int channel, int noteNumber, int velocity)
        {
            this.noteNumber = noteNumber;
            this.velocity = velocity;
        }

        public override string ToString()
        {
            return "NoteOn " + ' ' + channel + ' ' + noteNumber + ' ' + velocity;
        }
    }

    class OtherMidiEvent : MidiEvent
    {
        public int first, second;

        public OtherMidiEvent(int channel, int first, int second)
        {
            this.first = first;
            this.second = second;
        }

        public override string ToString()
        {
            return "Other " + ' ' + channel + ' ' + first + ' ' + second;
        }
    }

    abstract class MetaEvent : MidiEventBase
    {

    }
}
