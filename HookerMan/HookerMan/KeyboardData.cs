using System;
using System.Windows.Forms;
using LZSoft.HookerMan.WinApi;

namespace LZSoft.HookerMan
{
    public class KeyboardData
    {
        public Keys Key { get; }
        public string KeyName => Key.ToString();
        public int KeyCode { get; }
        public int ScanCode { get; }
        public int Flags { get; }
        public int Time { get; }
        public int DwExtraInfo { get; }
        public bool CapsPressed { get; }
        public bool ShiftPressed { get; }
        public bool ControlPressed { get; }
        public bool AltPressed { get; }
        public bool Down { get; }
        public bool Handled { get; set; }

        public KeyboardData(KBDLLHOOKSTRUCT kbdllhookstruct, bool down)
        {
            Down = down;
            KeyCode = kbdllhookstruct.vkCode;
            ScanCode = kbdllhookstruct.scanCode;
            Flags = kbdllhookstruct.flags;
            Time = kbdllhookstruct.time;
            DwExtraInfo = kbdllhookstruct.dwExtraInfo;
            if ((Imported.GetKeyState(Imported.VK_CAPITAL) & 0x0001) != 0)
                CapsPressed = true; //CAPSLOCK is ON
            if ((Imported.GetKeyState(Imported.VK_SHIFT) & 0x8000) != 0)
                ShiftPressed = true; //SHIFT is pressed
            if ((Imported.GetKeyState(Imported.VK_CONTROL) & 0x8000) != 0)
                ControlPressed = true; //CONTROL is pressed
            if ((Imported.GetKeyState(Imported.VK_MENU) & 0x8000) != 0)
                AltPressed = true; //ALT is pressed
            Key = (Keys)KeyCode;
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
                   $"{nameof(Time)}: {Time}{Environment.NewLine}" +
                   $"{nameof(Down)}: {Down}{Environment.NewLine}" +
                   $"{nameof(Key)}: {Key}{Environment.NewLine}";
        }
    }
}
