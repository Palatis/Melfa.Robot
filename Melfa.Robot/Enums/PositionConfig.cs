using System;

namespace Melfa.Robot;

[Flags]
public enum PositionConfig : byte
{
    LBF = PositionConfigSingle.Left | PositionConfigSingle.Below | PositionConfigSingle.Flip,
    LBN = PositionConfigSingle.Left | PositionConfigSingle.Below | PositionConfigSingle.NonFlip,
    LAF = PositionConfigSingle.Left | PositionConfigSingle.Above | PositionConfigSingle.Flip,
    LAN = PositionConfigSingle.Left | PositionConfigSingle.Above | PositionConfigSingle.NonFlip,
    RBF = PositionConfigSingle.Right | PositionConfigSingle.Below | PositionConfigSingle.Flip,
    RBN = PositionConfigSingle.Right | PositionConfigSingle.Below | PositionConfigSingle.NonFlip,
    RAF = PositionConfigSingle.Right | PositionConfigSingle.Above | PositionConfigSingle.Flip,
    RAN = PositionConfigSingle.Right | PositionConfigSingle.Above | PositionConfigSingle.NonFlip,
}