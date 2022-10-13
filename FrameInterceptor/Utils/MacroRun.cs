using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameInterceptor.Utils
{
    public class MacroRun : IDisposable
    {
        List<MacroCommand> _commands;
        List<MacroCommand> _responses;
        private int _ptr;
        private bool _disposed = false;
        private bool _firstRun = true;
        private bool _completed = false;

        public MacroRun(List<MacroCommand> iCommands, List<MacroCommand> iResponses)
        {
            if (iCommands.Count == 0)
                throw new ArgumentOutOfRangeException("iCommands");

            this._commands = iCommands;
            this._responses = iResponses;
            this._ptr = 0;
        }

        public bool Next(out byte[] oMessage)
        {
            this._firstRun = false;

            oMessage = this._commands[this._ptr].ByteData;

            this._ptr++;

            if (this._commands.Count == this._ptr)
            {
                this._completed = true;

                this.Dispose();

                return false;
            } 

            return true;
        }

        public bool IsAccepted(byte[] iResponse)
        {
            if (this._responses.Count == 0)
                return true;

            for (int i = 0; i < this._responses.Count; i++)
            {
                if (this._responses[i].ByteData.SequenceEqual(iResponse))
                    return true;
            }

            if (this.InterruptAfterBadResponse)
            {
                this._completed = true;

                this.Dispose();
            }

            return false;
        }

        public void Dispose()
        {
            this._ptr = 0;
            this._commands = null;
            this._responses = null;
            this._completed = true;

            this._disposed = true;
        }

        public bool InterruptAfterBadResponse { get; set; } = true;
        public int NextLength { get => this._commands[this._ptr].ByteData.Length; }
        public bool Completed { get => this._completed; }
        public bool FirstRun { get => this._firstRun; }
        public bool SerialSending { get => this._responses.Count == 0; }
        public bool Disposed { get => this._disposed; }
    }
}
