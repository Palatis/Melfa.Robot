using System;

namespace Melfa.Robot;

[Flags]
public enum MaintenanceResetTarget : byte
{
    Belt = 0x01,
    Grease = 0x02,
}