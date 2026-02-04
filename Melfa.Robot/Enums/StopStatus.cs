using System;

namespace Melfa.Robot;

[Flags]
public enum StopStatus : byte
{
    EmergencyStop = 0x01,
    Stop = 0x02,
    Wait = 0x04,
    StopSignal = 0x08,
    ProgramSelectEnabled = 0x10,
    Reserved = 0x20,
    PseudoInput = 0x40,
}