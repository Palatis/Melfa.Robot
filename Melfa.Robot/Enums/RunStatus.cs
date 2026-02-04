using System;

namespace Melfa.Robot;

[Flags]
public enum RunStatus : byte
{
    Repeat = 0x01,
    CycleStopOff = 0x02,
    MachineLockOn = 0x04,
    Teach = 0x08,
    TeachRunning = 0x10,
    ServoOn = 0x20,
    Running = 0x40,
    OperationEnabled = 0x80,
}