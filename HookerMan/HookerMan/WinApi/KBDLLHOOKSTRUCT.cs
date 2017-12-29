using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace LZSoft.HookerMan.WinApi
{
    [StructLayout(LayoutKind.Sequential)]
    public class KBDLLHOOKSTRUCT
    {
        public int vkCode;
        [UsedImplicitly] public int scanCode;
        public int flags;
        public int time;
        public int dwExtraInfo;
    }
}
