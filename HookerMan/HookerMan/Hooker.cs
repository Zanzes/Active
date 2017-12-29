using System;
using System.Text;
using System.Windows.Forms;
using LZSoft.HookerMan.WinApi;
using static LZSoft.HookerMan.WinApi.Imported;

namespace LZSoft.HookerMan
{
    public class Hooker
    {
        int _hhook = 123;
        readonly HookProc _hookProcedure;
        public event Action KeyEvent;
        public event Action<KeyboardData> KeyEventWData;
        public bool Enabled { get; private set; }

        private void CheckModifiers(ref KeyboardData data)
        {
            if ((GetKeyState(VK_CAPITAL) & 0x0001) != 0)
                data.CapsPressed = true; //CAPSLOCK is ON
            if ((GetKeyState(VK_SHIFT) & 0x8000) != 0)
                data.ShiftPressed = true; //SHIFT is pressed
            if ((GetKeyState(VK_CONTROL) & 0x8000) != 0)
                data.ControlPressed = true; //CONTROL is pressed
            if ((GetKeyState(VK_MENU) & 0x8000) != 0)
                data.AltPressed = true; //ALT is pressed
        }

        public Hooker(bool enable = true)
        {
            _hookProcedure = (nCode, wParam, lParam) =>
            {
                if (nCode < 0)
                    return CallNextHookEx(_hhook, nCode, wParam, lParam);

                var resStruct = lParam.DereferencePointer<KBDLLHOOKSTRUCT>();

                KeyEvent?.Invoke();
                var keyboardData = new KeyboardData(resStruct);
                keyboardData.KeyName = ((Keys) keyboardData.KeyCode).ToString();
                
                bool allowKey = keyboardData.Handled;
                if (wParam == (IntPtr)Imported.WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                {
                    if (!(keyboardData.KeyCode >= 160 && keyboardData.KeyCode <= 164))
                        CheckModifiers(ref keyboardData);

                    //switch (keyboardData.Flags)
                    //{
                    //    //Ctrl+Esc
                    //    case 0:
                    //        if (keyboardData.VkCode == 27)
                    //            allowKey = true;
                    //        break;

                    //    //Windows keys
                    //    case 1:
                    //        if ((keyboardData.VkCode == 91) || (keyboardData.VkCode == 92))
                    //            allowKey = true;
                    //        break;
                    //}
                }
                if ((keyboardData.Flags == 32) && (keyboardData.KeyCode == 9))
                    allowKey = true;

                KeyEventWData?.Invoke(keyboardData);

                return !keyboardData.Handled || allowKey ? CallNextHookEx(_hhook, nCode, wParam, lParam) : 1;
            };
            if (enable)
                Enable();
        }

        public void Enable()
        {
            if (Enabled)
                return;
            _hhook = SetWindowsHookEx(WH_KEYBOARD_LL, _hookProcedure, IntPtr.Zero, 0);
            AppDomain.CurrentDomain.ProcessExit += Disable;
            Enabled = true;
        }

        public void AddEvent(Action action) => KeyEvent += action;
        public void AddEvent(Action<KeyboardData> action) => KeyEventWData += action;

        public void Disable()
        {
            if (!Enabled)
                return;
            UnhookWindowsHookEx(_hhook);
            Enabled = false;
        }
        void Disable(object sender, EventArgs eventArgs)
        {
            Disable();
        }
    }
}
