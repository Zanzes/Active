using System;
using System.Runtime.InteropServices;

namespace HookerMan
{
    public class Hooker
    {
        int hhook = 123;
        Action<KBDLLHOOKSTRUCT> a;
        Imported.HookProc HookProcedure;
        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        public void Ds(Action<KBDLLHOOKSTRUCT> action)
        {
            a = action;
            //hhook = Imported.SetWindowsHookEx(L, HookProcedure, (IntPtr)0,Thread.CurrentThread.ManagedThreadId);

            hhook = Imported.SetWindowsHookEx(Imported.WH_KEYBOARD_LL, (nCode, wParam, lParam) =>
            {
                if (nCode < 0)
                    return Imported.CallNextHookEx(hhook, nCode, wParam, lParam);
                KBDLLHOOKSTRUCT MyMouseHookStruct = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));
                a(MyMouseHookStruct);

                return Imported.CallNextHookEx(hhook, nCode, wParam, lParam);
            }, IntPtr.Zero, 0);
        }

        ~Hooker()
        {
            Imported.UnhookWindowsHookEx(hhook);
        }
    }
}
