using System;

namespace Melfa.Robot
{
    [Flags]
    public enum StepMethod : byte
    {
        /// <summary>Execute one step forward</summary>
        Forward,
        /// <summary>Execute continuous forward</summary>
        Continuous,
        /// <summary>Execute one step backward</summary>
        Backward,
        /// <summary>Execute step stop</summary>
        Stop,
    }
}