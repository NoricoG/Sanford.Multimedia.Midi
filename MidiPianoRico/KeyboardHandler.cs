using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Sanford.Multimedia;
using Sanford.Multimedia.Midi;
using System.Windows.Forms;

namespace MidiPianoRico
{
    class KeyboardHandler
    {
        private const int SysExBufferSize = 128;
        private InputDevice inDevice = null;
        private SynchronizationContext context;

        private OutputDevice outDevice = null;
        private int controllerMode = 1;
        private Home home;

        public KeyboardHandler(Home home)
        {
            this.home = home;

            if (InputDevice.DeviceCount == 0)
            {
                MessageBox.Show("No MIDI input devices available.", "Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                home.Close();
            }
            else
            {
                try
                {
                    context = SynchronizationContext.Current;

                    inDevice = new InputDevice(0);
                    inDevice.ChannelMessageReceived += HandleChannelMessageReceived;
                    inDevice.SysCommonMessageReceived += HandleSysCommonMessageReceived;
                    inDevice.SysExMessageReceived += HandleSysExMessageReceived;
                    inDevice.SysRealtimeMessageReceived += HandleSysRealtimeMessageReceived;
                    inDevice.Error += new EventHandler<ErrorEventArgs>(inDevice_Error);

                    outDevice = new OutputDevice(0);

                    inDevice.StartRecording();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    home.Close();
                }
            }
        }

        private void HandleChannelMessageReceived(object sender, ChannelMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                if (e.Message.Command == ChannelCommand.Controller)
                    HandleControllerReceived(e.Message.Data2);
                outDevice.Send(e.Message);
            }, null);
        }

        private void HandleControllerReceived(int value)
        {
            if (value < 64)
            {
                if (controllerMode != 0)
                {
                    controllerMode = 0;
                    MessageBox.Show("Next page");
                }
            }
            else
            {
                if (controllerMode != 2)
                {
                    controllerMode = 2;
                    MessageBox.Show("Next page");
                }
            }
        }

        private void HandleSysCommonMessageReceived(object sender, SysCommonMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                MessageBox.Show("This has yet to be implemented");
            }, null);
        }

        private void HandleSysExMessageReceived(object sender, SysExMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                MessageBox.Show("This has yet to be implemented");
            }, null);
        }

        private void HandleSysRealtimeMessageReceived(object sender, SysRealtimeMessageEventArgs e)
        {
            context.Post(delegate (object dummy)
            {
                MessageBox.Show("This has yet to be implemented");
            }, null);
        }

        private void inDevice_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Error.Message, "Error!",
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
