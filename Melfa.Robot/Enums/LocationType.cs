namespace Melfa.Robot
{
    public enum LocationType : byte
    {
        /// <summary>[TOP] Top line / position</summary>
        Top = 1,
        /// <summary>[END] Bottom line / position</summary>
        Bottom = 2,
        /// <summary>[+1] Next line / position</summary>
        Next = 3,
        /// <summary>[-1] Previous line / position</summary>
        Previous = 4,
    }
}