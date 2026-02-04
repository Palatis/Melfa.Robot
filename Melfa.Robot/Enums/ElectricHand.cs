namespace Melfa.Robot;

public enum ElectricHandJogMode : byte
{
    /// <summary>Origin setting (EHOrg)</summary>
    Origin = 0x00,
    /// <summary>Hand open (EHOpen)</summary>
    Open = 0x01,
    /// <summary>Hand close (EHClose)</summary>
    Close = 0x02,
    /// <summary>Hand move (EHMov)</summary>
    Move = 0x03,
    /// <summary>Hand hold (EHHold)</summary>
    Hold = 0x04,
}