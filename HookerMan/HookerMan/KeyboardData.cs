using System;
using LZSoft.HookerMan.WinApi;

namespace LZSoft.HookerMan
{
    public class KeyboardData
    {
        public string KeyName { get; set; }
        public int KeyCode { get; }
        public bool Handled { get; set; }
        public int ScanCode { get; }
        public int Flags { get; }
        public int Time { get; }
        public int DwExtraInfo { get; }
        public bool CapsPressed { get; set; }
        public bool ShiftPressed { get; set; }
        public bool ControlPressed { get; set; }
        public bool AltPressed { get; set; }
        public KeyboardData(KBDLLHOOKSTRUCT kbdllhookstruct)
        {
            KeyCode = kbdllhookstruct.vkCode;
            ScanCode = kbdllhookstruct.scanCode;
            Flags = kbdllhookstruct.flags;
            Time = kbdllhookstruct.time;
            DwExtraInfo = kbdllhookstruct.dwExtraInfo;
        }

        public KeyboardData()
        {

        }

        public override string ToString()
        {
            return $"{nameof(Handled)}: {Handled}{Environment.NewLine}" +
                   $"{nameof(AltPressed)}: {AltPressed}{Environment.NewLine}" +
                   $"{nameof(CapsPressed)}: {CapsPressed}{Environment.NewLine}" +
                   $"{nameof(ControlPressed)}: {ControlPressed}{Environment.NewLine}" +
                   $"{nameof(ShiftPressed)}: {ShiftPressed}{Environment.NewLine}" +
                   $"{nameof(KeyCode)}: {KeyCode}{Environment.NewLine}" +
                   $"{nameof(KeyName)}: {KeyName}{Environment.NewLine}" +
                   $"{nameof(DwExtraInfo)}: {DwExtraInfo}{Environment.NewLine}" +
                   $"{nameof(Flags)}: {Flags}{Environment.NewLine}" +
                   $"{nameof(ScanCode)}: {ScanCode}{Environment.NewLine}" +
                   $"{nameof(Time)}: {Time}{Environment.NewLine}";
        }
    }
}
