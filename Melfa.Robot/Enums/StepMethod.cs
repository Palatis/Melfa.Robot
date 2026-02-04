using System;

namespace Melfa.Robot;

[Flags]
public enum StepMethod
{
    /// <summary>Execute one step forward</summary>
    Forward = 'I',
    /// <summary>Execute continuous forward</summary>
    Continuous = 'R',
    /// <summary>Execute one step backward</summary>
    Backward = 'B',
    /// <summary>Execute step stop</summary>
    Stop = 'S',
}