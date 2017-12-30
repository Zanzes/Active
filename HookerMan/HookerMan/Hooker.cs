using System;
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
        
        public Hooker(bool enable = true)
        {
            _hookProcedure = (nCode, wParam, lParam) =>
            {
                if (nCode < 0)
                    return CallNextHookEx(_hhook, nCode, wParam, lParam);

                var resStruct = lParam.DereferencePointer<KBDLLHOOKSTRUCT>();

                KeyEvent?.Invoke();
                bool down = !(wParam == (IntPtr) WM_KEYUP || wParam == (IntPtr) WM_SYSKEYUP);
                var keyboardData = new KeyboardData(resStruct,down);
                
                bool allowKey = keyboardData.Handled;
                //if (wParam == (IntPtr)Imported.WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
                //    if (!(keyboardData.KeyCode >= 160 && keyboardData.KeyCode <= 164))
                //        CheckModifiers(ref keyboardData);
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
