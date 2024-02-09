using System.ComponentModel;

namespace Melfa.Robot
{
    internal static class EnumExtensions
    {
        public static string ToCommandString(this HourMeterKind kind)
        {
            switch (kind)
            {
                case HourMeterKind.PowerOnTime: return "T";
                case HourMeterKind.ServoOnTime: return "S";
                case HourMeterKind.ProgramOperationTime: return "D";
                case HourMeterKind.BatteryAccumulationTime: return "B";
                case HourMeterKind.All: return "Z";
            }
            throw new InvalidEnumArgumentException(nameof(kind), (int)kind, typeof(HourMeterKind));
        }

        public static string ToCommandString(this StepMethod method)
        {
            switch (method)
            {
                case StepMethod.Forward: return "1";
                case StepMethod.Continuous: return "R";
                case StepMethod.Backward: return "B";
                case StepMethod.Stop: return "S";
            }
            throw new InvalidEnumArgumentException(nameof(method), (int)method, typeof(StepMethod));
        }
    }
}