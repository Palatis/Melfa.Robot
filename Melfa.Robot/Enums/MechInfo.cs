using System;

namespace Melfa.Robot;

[Flags]
public enum MechInfo : byte
{
    Mech1 = 0x01,
    Mech2 = 0x02,
    Mech3 = 0x04,
}