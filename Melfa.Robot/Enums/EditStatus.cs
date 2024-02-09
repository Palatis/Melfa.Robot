using System;

namespace Melfa.Robot
{
    [Flags]
    public enum EditStatus : byte
    {
        Editing = 0x01,
        Running = 0x02,
        Changed = 0x04,
    }
}