﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerInterface.Data
{
    [Flags]
    public enum Buttons : byte
    {
        Stick = 0b00000001,
        Button1 = 0b00000010,
        Button2 = 0b00000100,
        Button3 = 0b00001000,
        Button4 = 0b00010000,
    }
    public struct ArduinoData
    {
        public static int Size = 5;
        private byte[] _buffer;

        public Buttons Buttons => (Buttons)_buffer[0];
        public bool Button1 => ButtonEqual(Buttons.Button1);
        public bool Button2 => ButtonEqual(Buttons.Button2);
        public bool Button3 => ButtonEqual(Buttons.Button3);
        public bool Button4 => ButtonEqual(Buttons.Button4);
        public bool Stick => !ButtonEqual(Buttons.Stick);

        public short StickX => BitConverter.ToInt16(_buffer, 1);
        public short StickY => BitConverter.ToInt16(_buffer, 3);

        public ArduinoData(byte[] buffer)
        {
            _buffer = buffer;
        }

        public bool ButtonEqual(Buttons btn)
        {
            return (Buttons & btn) == btn;
        }
    }
}
