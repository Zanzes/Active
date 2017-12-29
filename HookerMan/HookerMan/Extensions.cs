using System;
using System.Runtime.InteropServices;

namespace LZSoft.HookerMan
{
    public static class Extensions
    {
        public static T DereferencePointer<T>(this IntPtr pointer) => (T)Marshal.PtrToStructure(pointer, typeof(T));
    }
}
