using System.Text.RegularExpressions;

namespace Melfa.Robot
{
    public partial class MelfaRobot
    {
        public readonly struct HandState
        {
            /// <summary>Signal number allocated in hand</summary>
            /// <remarks>-1: not used</remarks>
            public int SignalNumber { get; }
            /// <summary>Hand output status</summary>
            public bool? State { get; }
            /// <summary>Hand type</summary>
            public HandType HandType { get; }

            internal HandState(Match match)
            {
                SignalNumber = int.Parse(match.Groups[nameof(SignalNumber)].Value);
                switch (int.Parse(match.Groups[nameof(State)].Value))
                {
                    case 1: State = true; break;
                    case 2: State = false; break;
                    default: State = null; break;
                }
                HandType = (HandType)int.Parse(match.Groups[nameof(HandType)].Value);
            }
        }
    }
}