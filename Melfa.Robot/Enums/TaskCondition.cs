using System;

namespace Melfa.Robot;

[Flags]
public enum TaskCondition : byte
{
    Start = 0,
    Always = 1,
    Error = 2,
    Unknown = 0xff,
}