using System;

namespace Melfa.Robot
{
    [Flags]
    internal enum PositionConfigSingle : byte
    {
        Right = 0x04,
        Left = 0x00,
        Above = 0x02,
        Below = 0x00,
        NonFlip = 0x01,
        Flip = 0x00,
    }
}