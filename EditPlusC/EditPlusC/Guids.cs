// Guids.cs
// MUST match guids.h
using System;

namespace LZSoft.EditPlusC
{
    static class GuidList
    {
        public const string guidEditPlusCPkgString = "8313fa90-580e-4d20-a2e3-4002d2d195c8";
        public const string guidEditPlusCCmdSetString = "7da71698-b320-4987-9df7-64bf13898629";

        public static readonly Guid guidEditPlusCCmdSet = new Guid(guidEditPlusCCmdSetString);
    };
}