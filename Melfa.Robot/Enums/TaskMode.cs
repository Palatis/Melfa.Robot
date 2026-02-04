using System;

namespace Melfa.Robot;

[Flags]
public enum TaskMode : byte
{
    Repeat = 0,
    Cycle = 1,
    Unknown = 0xff,
}